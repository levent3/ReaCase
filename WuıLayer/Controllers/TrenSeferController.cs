using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using WuıLayer.Models.TrenIstasyon;
using WuıLayer.Models.TrenSefer;

namespace WuıLayer.Controllers
{
    public class TrenSeferController : Controller
    {
        private readonly ITrenSeferManager _trenSeferManager;
        private readonly ITrenIstasyonManager _trenIstasyonManager;

        public TrenSeferController(ITrenSeferManager trenSeferManager, ITrenIstasyonManager trenIstasyonManager)
        {
            _trenSeferManager = trenSeferManager;
            _trenIstasyonManager = trenIstasyonManager;
        }
        public IActionResult Index()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        {
            var trenSeferListesi = _trenSeferManager.GetList();
            var trenIstasyonListesi = _trenIstasyonManager.GetList();

            var result = from ts in trenSeferListesi
                         let kalkisIstasyon = trenIstasyonListesi.FirstOrDefault(x => x.Id == ts.TrenKalkisIstasyonId)
                         let varisIstasyon = trenIstasyonListesi.FirstOrDefault(x => x.Id == ts.TrenVarisIstasyonId)
                         select new TrenIstasyonListDTO
                         {
                             KalısSaati = ts.KalısSaati,
                             VarisSaati = ts.VarisSaati,
                             TrenKalkisIstasyonAdi = kalkisIstasyon?.IstasyonAdi,
                             TrenVarisIstasyonAdi = varisIstasyon?.IstasyonAdi,
                             Id = ts.Id,                             
                             TrenKalkisIstasyonId = ts.TrenKalkisIstasyonId,
                             TrenVarisIstasyonId = ts.TrenVarisIstasyonId   
                             
                         };

            return View(result.ToList());
        }





        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewData["TrenIstasyonlari"] = new SelectList(GetIstasyon(), "Id", "IstasyonAdi");
            var sefer = _trenSeferManager.Get(p => p.Id == Id);
            TrenSeferUpdateDTO updateDTO = new TrenSeferUpdateDTO()


            {
                id = sefer.Id,
                KalısSaati = sefer.KalısSaati,
                VarisSaati = sefer.VarisSaati,
                TrenVarisIstasyonId = sefer.TrenVarisIstasyonId,
                TrenKalkisIstasyonId = sefer.TrenKalkisIstasyonId 
            
            
            };
            return View(updateDTO);
        }



        [HttpPost]
        public IActionResult Update(TrenSeferUpdateDTO seferUpdateDTO)
        {
            ViewData["TrenIstasyonlari"] = new SelectList(GetIstasyon(), "Id", "IstasyonAdi");
            if (!ModelState.IsValid)
            {
                return View(seferUpdateDTO);

            }

            var sefer2 = _trenSeferManager.Get(p => p.Id == seferUpdateDTO.id);



            sefer2.KalısSaati = seferUpdateDTO.KalısSaati;
            sefer2.VarisSaati = seferUpdateDTO.VarisSaati;
            sefer2.TrenVarisIstasyonId = seferUpdateDTO.TrenVarisIstasyonId;
            sefer2.TrenKalkisIstasyonId = seferUpdateDTO.TrenKalkisIstasyonId;


           _trenSeferManager.Update(sefer2);

            return RedirectToAction("Index", "TrenSefer");



        }





        [HttpGet]
        public IActionResult Create()
        {

            var createDto = new TrenSeferCreateDTO();

            return View(createDto);


        }
        [HttpPost]
        public IActionResult Create(TrenSeferCreateDTO seferCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(seferCreateDTO);
                }

                var istasyonVarmi = _trenSeferManager.Get(p => p.Id == seferCreateDTO.id);
                //bool a = Convert.ToBoolean(odaVarmi);
                if (istasyonVarmi != null)
                {
                    //TempData["alertMessage"] = "Whatever you want to alert the user with";

                    ModelState.AddModelError("", "Bu oda daha onceden kaydedilmistir.");
                    return View(seferCreateDTO);




                }
                else
                {
                    TrenSefer sefer = new TrenSefer
                    {
                        KalısSaati = seferCreateDTO.KalısSaati,
                        VarisSaati = seferCreateDTO.VarisSaati,
                        TrenKalkisIstasyonId = seferCreateDTO.TrenKalkisIstasyonId,                   
                        TrenVarisIstasyonId = seferCreateDTO.TrenVarisIstasyonId

                    };



                    _trenSeferManager.Add(sefer);


                    return RedirectToAction("Index", "TrenSefer");


                }

            }
            catch (Exception ex)
            {

            }
            return View(seferCreateDTO);

        }


        private List<TrenIstasyon> GetIstasyon()
        {
            var result = _trenIstasyonManager.GetList();
            return result;
        }

    }
}
