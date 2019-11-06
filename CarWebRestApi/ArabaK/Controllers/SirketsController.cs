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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SOA_Web_Api.Models;
using System.Text;

namespace ArabaK.Controllers
{
    public class SirketsController : Controller
    {
        private SOAModel.Kullanici db = new SOAModel.Kullanici();

        // GET: Sirkets
        public ActionResult Index()
        {
            IEnumerable<Sirket> sirket = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                var responseTask = client.GetAsync("Sirket");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var value = result.Content.ReadAsStringAsync().Result;

                    var readTask = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();

                    sirket = readTask;
                }
                else
                {

                    sirket = Enumerable.Empty<Sirket>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
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
                    sirket = new Sirket()
                    {
                        SirketAd = sirket.SirketAd,
                        Sehir = sirket.Sehir,
                        SirketAdres = sirket.SirketAdres,
                        AracSayisi = sirket.AracSayisi
                    };

                    // Serialize C# object to Json Object
                    var serializedProduct = JsonConvert.SerializeObject(sirket);
                    // Json object to System.Net.Http content type
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    // Post Request to the URI
                    var postTask = client.PostAsJsonAsync<Sirket>("api/Sirket", sirket);

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(sirket);
        }

        // GET: Sirkets/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
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
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64124/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Sirket/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
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
