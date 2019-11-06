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
    public class SirketsController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();

        // GET: Sirkets
        public ActionResult Index()
        {
            return View(db.Sirket.ToList());
        }

        // GET: Sirkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirket.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        // GET: Sirkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sirkets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SirketID,SirketAd,Sehir,SirketAdres,AracSayisi")] Sirket sirket)
        {
            if (ModelState.IsValid)
            {
                db.Sirket.Add(sirket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sirket);
        }

        // GET: Sirkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirket.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        // POST: Sirkets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SirketID,SirketAd,Sehir,SirketAdres,AracSayisi")] Sirket sirket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sirket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sirket);
        }

        // GET: Sirkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirket sirket = db.Sirket.Find(id);
            if (sirket == null)
            {
                return HttpNotFound();
            }
            return View(sirket);
        }

        // POST: Sirkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sirket sirket = db.Sirket.Find(id);
            db.Sirket.Remove(sirket);
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
