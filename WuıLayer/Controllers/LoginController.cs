using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using WuıLayer.Models;

namespace WuıLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IKullaniciManager _kullaniciManager;

        public LoginController(IKullaniciManager kullaniciManager)
        {
            _kullaniciManager = kullaniciManager;
        }



        public IActionResult Giris()
        {

            LoginVM login = new LoginVM();
            return View(login);
         
        }


        [HttpPost]

        public IActionResult Giris(LoginVM login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }



            var kullanici = _kullaniciManager.Get(p => p.KullaniciAdi == login.KullaniciAdi && p.Sifre == login.Sifre);

            if (kullanici == null)
            {
                ModelState.AddModelError("", "Kullanici Adi Yada Sifre Hatalidir");
                return View(login);

            }

            return RedirectToAction("Index", "Home");   
        }
    }
}
