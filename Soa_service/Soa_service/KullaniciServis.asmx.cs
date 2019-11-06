using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SOABusiness;
using SOAModel;

namespace Soa_service
{
    /// <summary>
    /// Summary description for KullaniciServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KullaniciServis : System.Web.Services.WebService
    {
        [WebMethod]
        public bool InsertKullanici(Kullanici entity)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.InsertKullanici(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool UpdateKullanici(Kullanici entity)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.UpdateKullanici(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [WebMethod]
        public Kullanici[] SelectAllKullanici()
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    return business.SelectAllKullanici().ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public bool DeleteKullanici(int id)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.KullaniciDelete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public Kullanici KullaniciIdSelect(int id)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    return business.SelectedIdKullanici(id);
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

