using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAData.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        TEntity IdSelect(int id);
        IList<TEntity> SelectAll();
    }
}
