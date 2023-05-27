using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }
        public PartialViewResult PartialAddAbout()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.TInsert(about);
            return RedirectToAction("Index","About");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = aboutManager.TGetById(id);
            aboutManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}