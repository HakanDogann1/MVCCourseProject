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
    public class ImageFileManager : IImageFileService
    {
        private readonly IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public void TDelete(ImageFile entity)
        {
           _ımageFileDal.Delete(entity);
        }

        public ImageFile TGetById(int id)
        {
            return _ımageFileDal.GetById(id);
        }

        public List<ImageFile> TGetFilterList(Expression<Func<ImageFile, bool>> filter)
        {
           return _ımageFileDal.GetFilterList(filter);
        }

        public List<ImageFile> TGetList()
        {
            return _ımageFileDal.GetList();
        }

        public void TInsert(ImageFile entity)
        {
            _ımageFileDal.Insert(entity);
        }

        public void TUpdate(ImageFile entity)
        {
            _ımageFileDal.Update(entity);
        }
    }
}
