using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void TDelete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public Content TGetById(int id)
        {
            return _contentDal.GetById(id);
        }

        public List<Content> TGetFilterList(Expression<Func<Content, bool>> filter)
        {
            return _contentDal.GetFilterList(filter);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public void TInsert(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public void TUpdate(Content entity)
        {
            _contentDal.Update(entity);
        }
    }
}
