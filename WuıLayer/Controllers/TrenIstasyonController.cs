using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WuıLayer.Models.Kullanici;
using WuıLayer.Models.TrenIstasyon;

namespace WuıLayer.Controllers
{
    public class TrenIstasyonController : Controller
    {
        private readonly ITrenIstasyonManager _trenIstasyonManager;

        public TrenIstasyonController(ITrenIstasyonManager trenIstasyonManager)
        {
            _trenIstasyonManager = trenIstasyonManager;
        }
        public IActionResult Index()
        {

            var result = _trenIstasyonManager.FindAll();
            return View(result.ToList());
        }

      
        [HttpGet]
        public  IActionResult Update(int Id)
        {
            var istasyon = _trenIstasyonManager.Get(p => p.Id == Id);
            TrenIstasyonUpdateDTO updateDTO = new TrenIstasyonUpdateDTO()


            {
                id = istasyon.Id,
                IstasyonAdi = istasyon.IstasyonAdi,
                IstasyonAdresi = istasyon.IstasyonAdresi,
                IstasyonKonumu = istasyon.IstasyonKonumu



            };
            return View(updateDTO);
        }



        [HttpPost]
        public IActionResult Update(TrenIstasyonUpdateDTO istasyonUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(istasyonUpdateDTO);

            }

            var istasyon2 = _trenIstasyonManager.Get(p => p.Id == istasyonUpdateDTO.id);



            istasyon2.IstasyonAdresi = istasyonUpdateDTO.IstasyonAdresi;
            istasyon2.IstasyonKonumu = istasyonUpdateDTO.IstasyonKonumu;
            istasyon2.IstasyonAdi = istasyonUpdateDTO.IstasyonAdi;


             _trenIstasyonManager.Update(istasyon2);
         
             return RedirectToAction("Index", "TrenIstasyon");
            
          

        }



        [HttpGet]
        public  IActionResult Create()
        {

            var createDto = new TrenIstasyonCreateDTO();

            return View(createDto);


        }
        [HttpPost]
        public IActionResult Create(TrenIstasyonCreateDTO istasyonCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(istasyonCreateDTO);
                }

                var istasyonVarmi = _trenIstasyonManager.Get(p => p.Id == istasyonCreateDTO.id);
                //bool a = Convert.ToBoolean(odaVarmi);
                if (istasyonVarmi != null)
                {
                    //TempData["alertMessage"] = "Whatever you want to alert the user with";

                    ModelState.AddModelError("", "Bu oda daha onceden kaydedilmistir.");
                    return View(istasyonCreateDTO);




                }
                else
                {
                    TrenIstasyon istasyon = new TrenIstasyon
                    {
                        IstasyonAdi = istasyonCreateDTO.IstasyonAdi,
                        IstasyonAdresi = istasyonCreateDTO.IstasyonAdresi,
                        IstasyonKonumu = istasyonCreateDTO.IstasyonKonumu,
                        
                    };



                    _trenIstasyonManager.Add(istasyon);

                   
                     return RedirectToAction("Index", "TrenIstasyon");
                    
                
                }

            }
            catch (Exception ex)
            {

            }
            return View(istasyonCreateDTO);

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var istasyon = _trenIstasyonManager.Get(p => p.Id == Id);
            TrenIstasyonDeleteDTO deletDTO = new TrenIstasyonDeleteDTO()


            {
                id = istasyon.Id,
                IstasyonKonumu = istasyon.IstasyonKonumu,
                IstasyonAdi = istasyon.IstasyonAdi,
                IstasyonAdresi = istasyon.IstasyonAdresi
               
            
            
            
            };
            return View(deletDTO);
        }



        [HttpPost]
        public IActionResult Delete(TrenIstasyonDeleteDTO trenIstasyonDeleteDTO)
        {



            var istasyon = _trenIstasyonManager.Get(p => p.Id == trenIstasyonDeleteDTO.id);
            //bool a = Convert.ToBoolean(odaVarmi);





            _trenIstasyonManager.Delete(istasyon);


            return RedirectToAction("Index", "TrenIstasyon");







        }






    }
}
