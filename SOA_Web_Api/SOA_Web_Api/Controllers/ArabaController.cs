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
    public class ArabaController : ApiController
    {
        // GET: api/Araba
        public IHttpActionResult Get()
        {
            using (var ArabaBusiness = new ArabaBusiness())
            {
                List<Araba> AraList = ArabaBusiness.SelectAllAraba();
                var content = new ResponseContent<Araba>(AraList);
                return new StandartResults<Araba>(content, Request);
            }
        }
        // GET: api/Araba/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Araba> content;

            using (var ArabaBusiness = new ArabaBusiness())
            {

                List<Araba> araba = null;
                try
                {
                    var c = ArabaBusiness.SelectedIdAraba(id);
                    if (c != null)
                    {
                        araba = new List<Araba>();
                        araba.Add(c);
                    }
                    content = new ResponseContent<Araba>(araba);

                    return new XmlResult<Araba>(content, Request);
                }
                catch (Exception)
                {

                    content = new ResponseContent<Araba>(null);
                    return new XmlResult<Araba>(content, Request);
                }
            }
        }


        // POST: api/Araba
        public IHttpActionResult Post(Araba araba)
        {
            var content = new ResponseContent<Araba>(null);
            if (araba != null)
            {
                using (var ArabaBusiness = new ArabaBusiness())
                {
                    content.Result = ArabaBusiness.InsertAraba(araba) ? "1" : "0";

                    return new StandartResults<Araba>(content, Request);
                }
            }
            content.Result = "0";

            return new StandartResults<Araba>(content, Request);
        }

        // PUT: api/Araba/5
        public IHttpActionResult Put(Araba araba)
        {

            using (var ArabaBusiness = new ArabaBusiness())
            {
                ArabaBusiness.UpdateAraba(araba);
                return null;
            }

        }

        // DELETE: api/Araba/5
        public IHttpActionResult Delete(int id)
        {
            //ResponseContent<Kullanici> content;

            using (var ArabaBusiness = new ArabaBusiness())
            {
                ArabaBusiness.ArabaDelete(id);
                return null;
            }
        }
        
    }
}
