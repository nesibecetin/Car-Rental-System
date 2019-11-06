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
    /// Summary description for SirketServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SirketServis : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertSirket(Sirket entity)
        {
            try
            {
                using (var business = new SirketBusiness())
                {
                    business.InsertSirket(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public Sirket[] SelectAllSirket()
        {
            try
            {
                using (var business = new SirketBusiness())
                {
                    return business.SelectAllSirket().ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*  [WebMethod]
          public bool UpdateSirket(Sirket entity)
          {
              try
              {
                  using (var business = new SirketBusiness())
                  {
                      business.UpdateSirket(entity);
                  }
                  return true;
              }
              catch (Exception)
              {
                  return false;
              }
          }*/
    }
}
