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
    public class ArabasController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();

        // GET: Arabas
        public ActionResult Arabalar()
        {
            var araba = db.Araba;
            return View(araba.ToList());
        }
        public ActionResult ArabaDetay(int id)
        {
            var araba = db.Araba.Where(p => p.AracID == id).Take(1).ToList();
            return View("ArabaDetay", araba);
        }
        public ActionResult Index()
        {
            var araba = db.Araba.Include(a => a.Sirket1);
            return View(araba.ToList());
        }

        // GET: Arabas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        // GET: Arabas/Create
        public ActionResult Create()
        {
            ViewBag.Sirket = new SelectList(db.Sirket, "SirketID", "SirketAd");
            return View();
        }

        // POST: Arabas/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracID,AracMarka,AracModel,Plaka,EhliyetYasi,YasSiniri,GunlukSinirKilometre,AnlikKilometre,Airbag,BagajHacmi,KoltukSayisi,KiralamaBedeli,Sirket,Resim,Durum")] Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Araba.Add(araba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sirket = new SelectList(db.Sirket, "SirketID", "SirketAd", araba.Sirket);
            return View(araba);
        }

        // GET: Arabas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sirket = new SelectList(db.Sirket, "SirketID", "SirketAd", araba.Sirket);
            return View(araba);
        }

        // POST: Arabas/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracID,AracMarka,AracModel,Plaka,EhliyetYasi,YasSiniri,GunlukSinirKilometre,AnlikKilometre,Airbag,BagajHacmi,KoltukSayisi,KiralamaBedeli,Sirket,Resim,Durum")] Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(araba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sirket = new SelectList(db.Sirket, "SirketID", "SirketAd", araba.Sirket);
            return View(araba);
        }

        // GET: Arabas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        // POST: Arabas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araba araba = db.Araba.Find(id);
            db.Araba.Remove(araba);
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
