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
	public class MySkillManager : IMySkillService
	{
		private readonly IMySkillDal _mySkillDal;

		public MySkillManager(IMySkillDal mySkillDal)
		{
			_mySkillDal = mySkillDal;
		}

		public void TDelete(MySkill entity)
		{
			_mySkillDal.Delete(entity);
		}

		public MySkill TGetById(int id)
		{
			return _mySkillDal.GetById(id);
		}

		public List<MySkill> TGetFilterList(Expression<Func<MySkill, bool>> filter)
		{
			return _mySkillDal.GetFilterList(filter);
		}

		public List<MySkill> TGetList()
		{
			return _mySkillDal.GetList();
		}

		public void TInsert(MySkill entity)
		{
			_mySkillDal.Insert(entity);
		}

		public void TUpdate(MySkill entity)
		{
			_mySkillDal.Update(entity);
		}
	}
}
