using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using SOAData.Concretes;

namespace SOABusiness.Concretes
{
    public class KiralamaBusiness : IDisposable

    {
        public KiralamaBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public bool InsertKiralama(Kiralama entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralamaRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SOABusiness:KiralamaBusiness::InsertKiralama::Error occured.", ex);
            }
        }

        public bool KiralamaDelete(int KiralamaId)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralamaRepository())
                {
                    isSuccess = repo.Delete(KiralamaId);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("KiralamaBusiness:KiralamaRepository:Silme Hatası", ex);
            }
        }

        public bool UpdateKiralama(Kiralama entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new KiralamaRepository())
                {
                    isSuccess = repo.Update(entity);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("KiralamaBusiness:KiralamaRepository:Güncelleme Hatası", ex);
            }
        }

        public Kiralama SelectedIdKiralama(int KiralamaId)
        {
            try
            {
                Kiralama responseEntitiy;
                using (var repo = new KiralamaRepository())
                {
                    responseEntitiy = repo.IdSelect(KiralamaId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Kiralama doesnt exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("KiralamaBusiness:KiralamaRepository:SelectCustomerById::Error occured.", ex);
            }
        }

        public List<Kiralama> SelectAllKiralama()
        {
            var responseEntities = new List<Kiralama>();

            try
            {
                using (var repo = new KiralamaRepository())
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
                throw new Exception("SOABusinessKiralamaBusiness:KiralamaRepository:SelectAllKiralama::Error occured.", ex);
            }
        }
    }
}
