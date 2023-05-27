using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TDelete(T entity);
        void TUpdate(T entity);
        void TInsert(T entity);
        List<T> TGetList();
        List<T> TGetFilterList(Expression<Func<T, bool>> filter);
        T TGetById(int id);
    }
}
