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
    public class KiralamaBilgiController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();

        // GET: KiralamaBilgi
        public ActionResult Index()
        {
            var kiralamaBilgi = db.KiralamaBilgi.Include(k => k.Araba).Include(k => k.Kullanici1);
            return View(kiralamaBilgi.ToList());
        }

        // GET: KiralamaBilgi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiralamaBilgi kiralamaBilgi = db.KiralamaBilgi.Find(id);
            if (kiralamaBilgi == null)
            {
                return HttpNotFound();
            }
            return View(kiralamaBilgi);
        }

        // GET: KiralamaBilgi/Create
        public ActionResult Create()
        {
            ViewBag.Arac = new SelectList(db.Araba, "AracID", "AracMarka");
            ViewBag.Kullanici = new SelectList(db.Kullanici, "KullaniciID", "Ad");
            return View();
        }

        // POST: KiralamaBilgi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KiralamaID,Ad,Soyad,Telefon,Email,VerilisTarihi,AlinisTarihi,VerilisKilometre,GidilenKilometre,AlinanUcret,Arac")] KiralamaBilgi kiralamaBilgi)
        {
            if (ModelState.IsValid)
            {
                db.KiralamaBilgi.Add(kiralamaBilgi);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Arac = new SelectList(db.Araba, "AracID", "AracMarka", kiralamaBilgi.Arac);
            ViewBag.Kullanici = new SelectList(db.Kullanici, "KullaniciID", "Ad", kiralamaBilgi.Kullanici);
            return RedirectToAction("Index", "Home");
        }

        // GET: KiralamaBilgi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiralamaBilgi kiralamaBilgi = db.KiralamaBilgi.Find(id);
            if (kiralamaBilgi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Arac = new SelectList(db.Araba, "AracID", "AracMarka", kiralamaBilgi.Arac);
            ViewBag.Kullanici = new SelectList(db.Kullanici, "KullaniciID", "Ad", kiralamaBilgi.Kullanici);
            return View(kiralamaBilgi);
        }

        // POST: KiralamaBilgi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KiralamaID,Ad,Soyad,Telefon,Email,VerilisTarihi,AlinisTarihi,VerilisKilometre,GidilenKilometre,AlinanUcret,Arac")] KiralamaBilgi kiralamaBilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kiralamaBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Arac = new SelectList(db.Araba, "AracID", "AracMarka", kiralamaBilgi.Arac);
            ViewBag.Kullanici = new SelectList(db.Kullanici, "KullaniciID", "Ad", kiralamaBilgi.Kullanici);
            return View(kiralamaBilgi);
        }

        // GET: KiralamaBilgi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KiralamaBilgi kiralamaBilgi = db.KiralamaBilgi.Find(id);
            if (kiralamaBilgi == null)
            {
                return HttpNotFound();
            }
            return View(kiralamaBilgi);
        }

        // POST: KiralamaBilgi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KiralamaBilgi kiralamaBilgi = db.KiralamaBilgi.Find(id);
            db.KiralamaBilgi.Remove(kiralamaBilgi);
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
