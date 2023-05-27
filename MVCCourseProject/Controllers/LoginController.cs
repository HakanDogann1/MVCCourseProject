using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCourseProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = adminManager.TSignIn(x=>x.UserName == admin.UserName && x.Password==admin.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"]=admin.UserName;
                return RedirectToAction("Index","Category");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}