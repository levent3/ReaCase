using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using WuıLayer.Models.Kullanici;
using WuıLayer.Models.TrenIstasyon;

namespace WuıLayer.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager _kullaniciManager;

        public KullaniciController(IKullaniciManager kullaniciManager)
        {
            _kullaniciManager = kullaniciManager;
        }
        public IActionResult Index()
        {

            var result=_kullaniciManager.GetList();

            return View(result.ToList());
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            var kullanici = _kullaniciManager.Get(p => p.Id == Id);
            KullaniciUpdateDTO updateDTO = new KullaniciUpdateDTO()


            {
                id = kullanici.Id,
                KullaniciAdi = kullanici.KullaniciAdi,
                Sifre = kullanici.Sifre,
              



            };
            return View(updateDTO);
        }



        [HttpPost]
        public IActionResult Update(KullaniciUpdateDTO kullaniciUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(kullaniciUpdateDTO);

            }

            var kullanici2 = _kullaniciManager.Get(p => p.Id == kullaniciUpdateDTO.id);



            kullanici2.KullaniciAdi= kullaniciUpdateDTO.KullaniciAdi;
            kullanici2.Sifre = kullaniciUpdateDTO.Sifre;
           


            _kullaniciManager.Update(kullanici2);

            return RedirectToAction("Index", "Kullanici");



        }



        [HttpGet]
        public IActionResult Create()
        {

            var createDto = new KullaniciCreateDto();

            return View(createDto);


        }
        [HttpPost]
        public IActionResult Create(KullaniciCreateDto kullaniciCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(kullaniciCreateDTO);
                }

                var istasyonVarmi = _kullaniciManager.Get(p => p.Id == kullaniciCreateDTO.id);
                //bool a = Convert.ToBoolean(odaVarmi);
                if (istasyonVarmi != null)
                {
                    //TempData["alertMessage"] = "Whatever you want to alert the user with";

                    ModelState.AddModelError("", "Bu oda daha onceden kaydedilmistir.");
                    return View(kullaniciCreateDTO);




                }
                else
                {
                    Kullanici istasyon = new Kullanici
                    {
                        KullaniciAdi= kullaniciCreateDTO.KullaniciAdi,
                        Sifre= kullaniciCreateDTO.Sifre,
                       

                    };



                    _kullaniciManager.Add(istasyon);


                    return RedirectToAction("Index", "Kullanici");


                }

            }
            catch (Exception ex)
            {

            }
            return View(kullaniciCreateDTO);

        }
    }
}
