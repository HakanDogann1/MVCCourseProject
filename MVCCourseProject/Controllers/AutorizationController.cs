using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    public class AutorizationController : Controller
    {
        // GET: Autorization
        AdminManager adminManager=new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var values = adminManager.TGetList();
            return View(values);
        }
    }
}