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
    public class SirketController : ApiController
    {
        // GET: api/Sirket
        public IHttpActionResult Get()
        {
              
            using (var SirketBusiness = new SirketBusiness())
            {
                
                List<Sirket> sirlist = SirketBusiness.SelectAllSirket();
                var content = new ResponseContent<Sirket>(sirlist);
                return new StandartResults<Sirket>(content, Request);
            }
        }

        // GET: api/Sirket/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Sirket> content;

            using (var SirketBusiness = new SirketBusiness())
            {

                List<Sirket> sirket = null;
                try
                {
                    var c = SirketBusiness.SelectedIdSirket(id);
                    if (c != null)
                    {
                        sirket = new List<Sirket>();
                        sirket.Add(c);
                    }
                    content = new ResponseContent<Sirket>(sirket);

                    return new XmlResult<Sirket>(content, Request);
                }
                catch (Exception)
                {

                    content = new ResponseContent<Sirket>(null);
                    return new XmlResult<Sirket>(content, Request);
                }
            }
        }

        // POST: api/Sirket
        public IHttpActionResult Post(Sirket sirket)
        {
            var content = new ResponseContent<Sirket>(null);
            if (sirket != null)
            {
                using (var SirketBusiness = new SirketBusiness())
                {
                    content.Result = SirketBusiness.InsertSirket(sirket) ? "1" : "0";

                    return new StandartResults<Sirket>(content, Request);
                }
            }
            content.Result = "0";

            return new StandartResults<Sirket>(content, Request);
        }
        // PUT: api/Sirket/5
        public IHttpActionResult Put(Sirket sirket)
        {

            using (var SirketBusiness = new SirketBusiness())
            {
                SirketBusiness.UpdateSirket(sirket);
                return null;
            }

        }

        // DELETE: api/Sirket/5
        public IHttpActionResult Delete(int id)
        {
            //ResponseContent<Kullanici> content;

            using (var SirketBusiness = new SirketBusiness())
            {
                SirketBusiness.SirketDelete(id);
                return null;
            }
        }
    }
}
