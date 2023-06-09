using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    public class MySkillController : Controller
    {
        // GET: MySkill
        MySkillManager skillManager = new MySkillManager(new EfMySkillDal());
        public ActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
    }
}