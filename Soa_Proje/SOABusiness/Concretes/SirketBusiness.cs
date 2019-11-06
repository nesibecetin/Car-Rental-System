using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using SOAData.Concretes;

namespace SOABusiness.Concretes
{
    public class SirketBusiness : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public SirketBusiness()
        {
             
        }
        public bool InsertSirket(Sirket entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SOABusiness:SirketBusiness::InsertSirket::Error occured.", ex);
            }
        }
        public List<Sirket> SelectAllSirket()
        {
            var responseEntities = new List<Sirket>();

            try
            {
                using (var repo = new SirketRepository())
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
                throw new Exception("SOABusiness:SirketBusiness::SelectAllSirket::Error occured.", ex);
            }
        }
        public bool SirketDelete(int SirketId)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.Delete(SirketId);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness::SirketRepository:Silme Hatası", ex);
            }
        }

        public bool UpdateSirket(Sirket entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new SirketRepository())
                {
                    isSuccess = repo.Update(entity);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness:SirketRepository:Güncelleme Hatası", ex);
            }
        }

        public Sirket SelectedIdSirket(int SirketId)
        {
            try
            {
                Sirket responseEntitiy;
                using (var repo = new SirketRepository())
                {
                    responseEntitiy = repo.IdSelect(SirketId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Sirket doesnt exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("SirketBusiness::SelectSirketrById::Error occured.", ex);
            }
        }
    }
}
