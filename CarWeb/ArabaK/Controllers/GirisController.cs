using ArabaK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ArabaK.Controllers
{
    public class GirisController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();
        // GET: Giris
        public ActionResult Index() => View();
        [Route("Uye-Giris")]
        public ActionResult Giris()
        {
            return View();
        }
        [Route("Uye-Giris")]
        [HttpPost]
        public ActionResult Giris(Kullanici kisi, string sifre)
        {
            var login = db.Kullanici.Where(m => m.Email == kisi.Email).FirstOrDefault();
            if (login.Email == kisi.Email && login.Sifre == kisi.Sifre)
            {
                Session["KisiId"] = login.KullaniciID;
                Session["KisiAdi"] = login.Ad;
                Session["KisiSoyadi"] = login.Soyad;
                Session["KisiEmail"] = login.Email;
                Session["KisiTel"] = login.Telefon;
                Session["Rol"] = login.Rol;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("KayıtOl", "Home");
            }

        }

        public ActionResult Cikis()
        {
            Session["KisiId"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}