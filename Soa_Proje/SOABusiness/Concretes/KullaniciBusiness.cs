using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using SOAData.Concretes;

namespace SOABusiness
{
    public class KullaniciBusiness : IDisposable
    {

        public bool InsertKullanici( Kullanici entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SOABusiness:KullaniciBusiness::InsertKullanici::Error occured.", ex);
            }
        }

        public bool KullaniciDelete(int KullaniciId)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.Delete(KullaniciId);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Silme Hatası", ex);
            }
        }

        public bool UpdateKullanici(Kullanici entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KullaniciRepository())
                {
                    isSuccess = repo.Update(entity);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("KullaniciBusiness:KullaniciRepository:Güncelleme Hatası", ex);
            }
        }

        public Kullanici SelectedIdKullanici(int KullaniciId)
        {
            try
            {
                Kullanici responseEntitiy;
                using (var repo = new KullaniciRepository())
                {
                    responseEntitiy = repo.IdSelect(KullaniciId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Customer doesnt exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:CustomerBusiness::SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Kullanici> SelectAllKullanici()
        {
            var responseEntities = new List<Kullanici>();

            try
            {
                using (var repo = new KullaniciRepository())
                {
                    foreach (var entity in repo.SelectAll())
                    {
                        responseEntities.Add(entity);
                    }
                }
                return responseEntities;
            }
            catch (Exception ex)
            {
                throw new Exception("SOABusiness:KullaniciBusiness::SelectAllKullanici::Error occured.", ex);
            }
        }

        public KullaniciBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
