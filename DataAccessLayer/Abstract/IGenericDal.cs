using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
        List<T> GetList();
        List<T> GetFilterList(Expression<Func<T, bool>> filter);
        T GetById(int id);
    }
}
