using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SOABusiness.Concretes;
using SOAModel;

namespace Soa_service
{
    /// <summary>
    /// Summary description for ArabaServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ArabaServis : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertAraba(Araba entity)
        {
            try
            {
                using (var business = new ArabaBusiness())
                {
                    business.InsertAraba(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [WebMethod]
        public Araba[] SelectAllAraba()
        {
            try
            {
                using (var business = new ArabaBusiness())
                {
                    return business.SelectAllAraba().ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

