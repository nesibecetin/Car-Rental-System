using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArabaK.Models;

namespace ArabaK.Controllers
{
    public class KullanicisController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();

        // GET: Kullanicis
        public ActionResult Index()
        {
            return View(db.Kullanici.ToList());
        }

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

        // GET: Kullanicis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanicis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanicis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KullaniciID,Ad,Soyad,Adres,Telefon,Email,Sifre,Rol")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanici);
        }

        // GET: Kullanicis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KullaniciID,Ad,Soyad,Adres,Telefon,Email,Sifre,Rol")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
