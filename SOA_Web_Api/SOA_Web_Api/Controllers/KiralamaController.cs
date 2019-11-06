using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOA_Web_Api.Models;
using SOA_Web_Api.Results;
using SOABusiness.Concretes;
using SOAModel;

namespace SOA_Web_Api.Controllers
{
    public class KiralamaController : ApiController
    {
        // GET: api/Kiralama
        public IHttpActionResult Get()
        {
            using (var KiralamaBusiness = new KiralamaBusiness())
            {
                List<Kiralama> AraList = KiralamaBusiness.SelectAllKiralama();
                var content = new ResponseContent<Kiralama>(AraList);
                return new StandartResults<Kiralama>(content, Request);
            }
        }

        // GET: api/Kiralama/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Kiralama> content;

            using (var KiralamaBusiness = new KiralamaBusiness())
            {

                List<Kiralama> kiralama = null;
                try
                {
                    var c = KiralamaBusiness.SelectedIdKiralama(id);
                    if (c != null)
                    {
                        kiralama = new List<Kiralama>();
                        kiralama.Add(c);
                    }
                    content = new ResponseContent<Kiralama>(kiralama);

                    return new XmlResult<Kiralama>(content, Request);
                }
                catch (Exception)
                {

                    content = new ResponseContent<Kiralama>(null);
                    return new XmlResult<Kiralama>(content, Request);
                }
            }
        }

        // POST: api/Kiralama
        public IHttpActionResult Post(Kiralama kiralama)
        {
            var content = new ResponseContent<Kiralama>(null);
            if (kiralama != null)
            {
                using (var KiralamaBusiness = new KiralamaBusiness())
                {
                    content.Result = KiralamaBusiness.InsertKiralama(kiralama) ? "1" : "0";

                    return new StandartResults<Kiralama>(content, Request);
                }
            }
            content.Result = "0";

            return new StandartResults<Kiralama>(content, Request);
        }

        // PUT: api/Kiralama/5
        public IHttpActionResult Put(Kiralama kiralama)
        {

            using (var KiralamaBusiness = new KiralamaBusiness())
            {
                KiralamaBusiness.UpdateKiralama(kiralama);
                return null;
            }

        }

        // DELETE: api/Kiralama/5
        public IHttpActionResult Delete(int id)
        {
            //ResponseContent<Kullanici> content;

            using (var KiralamaBusiness = new KiralamaBusiness())
            {
                KiralamaBusiness.KiralamaDelete(id);
                return null;
            }
        }
    }
}
