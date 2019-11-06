using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOA_Web_Api.Models;
using SOA_Web_Api.Results;
using SOABusiness;
using SOAModel;

namespace SOA_Web_Api.Controllers
{
    public class KullaniciController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            using (var KullaniciBusiness = new KullaniciBusiness())
            {
                List<Kullanici> kulList = KullaniciBusiness.SelectAllKullanici(); 
                var content = new ResponseContent<Kullanici>(kulList);
                return new StandartResults<Kullanici>(content, Request);
            }
        }

        public IHttpActionResult Get(int id)
        {
            ResponseContent<Kullanici> content;

            using (var KullaniciBusiness = new KullaniciBusiness())
            {
                
                List<Kullanici> customers = null;
                try
                {
                    var c = KullaniciBusiness.SelectedIdKullanici(id);
                    if (c != null)
                    {
                        customers = new List<Kullanici>();
                        customers.Add(c);
                    }
                    content = new ResponseContent<Kullanici>(customers);

                    return new XmlResult<Kullanici>(content, Request);
                }
                catch (Exception)
                {
                   
                    content = new ResponseContent<Kullanici>(null);
                    return new XmlResult<Kullanici>(content, Request);
                }
            }
        }


        // POST api/values
        public IHttpActionResult Post(Kullanici kullanici)
        {
            var content = new ResponseContent<Kullanici>(null);
            if (kullanici != null)
            {
                using (var KullaniciBusiness = new KullaniciBusiness())
                {
                    content.Result = KullaniciBusiness.InsertKullanici(kullanici) ? "1" : "0";

                    return new StandartResults<Kullanici>(content, Request);
                }
            }
            content.Result = "0";

            return new StandartResults<Kullanici>(content, Request);
        }

        // PUT api/values/5
        public IHttpActionResult Put(Kullanici kullanici)
        {

                using (var KullaniciBusiness = new KullaniciBusiness())
                {
                    KullaniciBusiness.UpdateKullanici(kullanici);
                    return null;
                }
   
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            //ResponseContent<Kullanici> content;

            using (var KullaniciBusiness = new KullaniciBusiness())
            {                
                KullaniciBusiness.KullaniciDelete(id);
                return null;
            }
        }
    }
}
