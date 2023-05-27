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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin TGetById(int id)
        {
           return _adminDal.GetById(id);
        }

        public List<Admin> TGetFilterList(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.GetFilterList(filter);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }

        public void TInsert(Admin entity)
        {
             _adminDal.Insert(entity);
        }

        public Admin TSignIn(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.SignIn(filter);
        }

        public void TUpdate(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
