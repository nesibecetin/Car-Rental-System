using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SOABusiness;
using SOAModel;
using SOA_Web_Api;
using Newtonsoft.Json;
using SOA_Web_Api.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace ArabaK.Controllers
{
    public class ArabasController : Controller
    {
        

        // GET: Arabas
        public ActionResult Arabalar()
        {
            IEnumerable<Araba> araba = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                var responseTask = client.GetAsync("Araba");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var value = result.Content.ReadAsStringAsync().Result;

                    var readTask = JsonConvert.DeserializeObject<ResponseContent<Araba>>(value).Data.ToList();

                    araba = readTask;
                }
                else
                {

                    araba = Enumerable.Empty<Araba>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(araba);
        }
        /*public ActionResult ArabaDetay(int id)
        {
            var araba = db.Araba.Where(p => p.AracID == id).Take(1).ToList();
            return View("ArabaDetay", araba);
        }*/
        public ActionResult Index()
        {
            IEnumerable<Araba> araba = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                var responseTask = client.GetAsync("Araba");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var value = result.Content.ReadAsStringAsync().Result;

                    var readTask = JsonConvert.DeserializeObject<ResponseContent<Araba>>(value).Data.ToList();

                    araba = readTask;
                }
                else
                {

                    araba = Enumerable.Empty<Araba>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(araba);
        }

        /*// GET: Arabas/Details/5
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
        }*/

        // GET: Arabas/Create
        public ActionResult Create()
        {
            //ViewBag.Sirket = new SelectList(SOAModel.Sirket, "SirketID", "SirketAd");
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
                bool success = false;
                // Create a HttpClient
                using (var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create post body object
                    araba = new Araba()
                    {
                        AracMarka = araba.AracMarka,
                        AracModel = araba.AracModel,
                        Plaka = araba.Plaka,
                        EhliyetYasi = araba.EhliyetYasi,
                        YasSiniri = araba.YasSiniri,
                        GunkukSinirKilometre = araba.GunkukSinirKilometre,
                        AnlikKilometre = araba.AnlikKilometre,
                        Airbag = araba.Airbag,
                        BagajHacmi = araba.BagajHacmi,
                        KoltukSayisi = araba.KoltukSayisi,
                        KiralamaBedeli = araba.KiralamaBedeli,
                        Sirket = araba.Sirket,
                        Resim = araba.Resim,
                        Durum = araba.Durum
                    };

                    // Serialize C# object to Json Object
                    var serializedProduct = JsonConvert.SerializeObject(araba);
                    // Json object to System.Net.Http content type
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    // Post Request to the URI
                    var postTask = client.PostAsJsonAsync<Araba>("api/Araba", araba);

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                return RedirectToAction("Index");
            }

            //ViewBag.Sirket = new SelectList(SOAModel.Sirket, "SirketID", "SirketAd", araba.Sirket);
            return View(araba);
            /*if (ModelState.IsValid)
            {
                db.Araba.Add(araba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sirket = new SelectList(db.Sirket, "SirketID", "SirketAd", araba.Sirket);
            return View(araba);*/
        }


        public ActionResult Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Araba/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        /* // GET: Arabas/Edit/5
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
         }*/
    }
}
