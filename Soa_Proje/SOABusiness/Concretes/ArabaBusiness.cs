using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAModel;
using SOAData.Concretes;

namespace SOABusiness.Concretes
{
    public class ArabaBusiness:IDisposable
    {
        public ArabaBusiness()
        {
            //Auto-generated Code   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public bool InsertAraba(Araba entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new ArabaRepository())
                {

                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("SOABusiness:ArabaBusiness::InsertAraba::Error occured.", ex);
            }
        }

        public List<Araba> SelectAllAraba()
        {
            var responseEntities = new List<Araba>();

            try
            {
                using (var repo = new ArabaRepository())
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
                throw new Exception("SOABusiness:ArabaBusiness::SelectAllAraba::Error occured.", ex);
            }
        }
        public bool ArabaDelete(int ArabaId)
        {
            try
            {
                bool isSuccess;
                using (var repo = new ArabaRepository())
                {
                    isSuccess = repo.Delete(ArabaId);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("ArabaBusiness:ArabaRepository:Silme Hatası", ex);
            }
        }

        public bool UpdateAraba(Araba entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new ArabaRepository())
                {
                    isSuccess = repo.Update(entity);

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("ArabaBusiness:ArabaRepository:Güncelleme Hatası", ex);
            }
        }

        public Araba SelectedIdAraba(int ArabaId)
        {
            try
            {
                Araba responseEntitiy;
                using (var repo = new ArabaRepository())
                {
                    responseEntitiy = repo.IdSelect(ArabaId);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Araba doesnt exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                throw new Exception("ArabaBusiness::SelectCustomerById::Error occured.", ex);
            }
        }
    }
}
