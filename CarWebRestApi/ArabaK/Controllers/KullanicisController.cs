using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SOAModel;
using SOABusiness;
using SOA_Web_Api.Models;

namespace ArabaK.Controllers
{
    public class KullanicisController : Controller
    {
        private SOAModel.Kullanici db = new SOAModel.Kullanici();

        // GET: Kullanicis
        public ActionResult Index()
        {
            IEnumerable<Kullanici> kullanici = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                var responseTask = client.GetAsync("Kullanici");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var value = result.Content.ReadAsStringAsync().Result;

                    var readTask = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();                

                    kullanici = readTask;
                }
                else 
                {

                    kullanici = Enumerable.Empty<Kullanici>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
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
        public  ActionResult Create([Bind(Include = "KullaniciID,Ad,Soyad,Adres,Telefon,Email,Sifre,Rol")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                bool success = false;
                // Create a HttpClient
                using(var client = new HttpClient())
                {
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:64124/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create post body object
                    kullanici = new Kullanici()
                    {
                        Ad = kullanici.Ad,
                        Soyad = kullanici.Soyad,
                        Adres = kullanici.Adres,
                        Telefon = kullanici.Telefon,
                        Email = kullanici.Email,
                        Sifre = kullanici.Sifre,
                        Rol = kullanici.Rol
                    };

                    // Serialize C# object to Json Object
                    var serializedProduct = JsonConvert.SerializeObject(kullanici);
                    // Json object to System.Net.Http content type
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    // Post Request to the URI
                    var postTask = client.PostAsJsonAsync<Kullanici>("api/Kullanici", kullanici);

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public ActionResult Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Kullanici/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        /* POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/");
                 client.DefaultRequestHeaders.Accept.Clear();
                 client.DefaultRequestHeaders.Accept.Add(
                     new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = client.PostAsJsonAsync<Kullanici>("api/Kullanici", kullanici);

                var result = postTask.Result;
               var result = client.DeleteAsync("api/Kullanici/" + id);
            }

            return RedirectToAction("Index");
        }


        /* GET: Kullanicis/Details/5
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
                
                return RedirectToAction("Index");
            }            
            return View(kullanici);
        }
/*
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
        }*/

        /* protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }


         private async void InsertKullanici(string ad, string soyad, string adres, string tel, string email, string sifre, string rol)
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
                 Kullanici kullanici = new Kullanici()
                 {
                     Ad = ad,
                     Soyad = soyad,
                     Adres = adres,
                     Telefon = tel,
                     Email = email,
                     Sifre = sifre,
                     Rol = rol
                 };

                 // Serialize C# object to Json Object
                 var serializedProduct = JsonConvert.SerializeObject(kullanici);
                 // Json object to System.Net.Http content type
                 var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                 // Post Request to the URI
                 var result = await client.PostAsync("api/Kullanici", content);
             }
         }*/
    }
}
