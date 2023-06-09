using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
    [AllowAnonymous]
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
            string HashPassword = Encrypt.MD5Create(admin.Password);

			var values = adminManager.TSignIn(x=>x.UserName == admin.UserName && x.Password== HashPassword);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"]=admin.UserName;
                return RedirectToAction("Index","Category");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Context context = new Context();
            var values = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["writermail"] = writer.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            return RedirectToAction("WriterLogin");

        }
    }
}