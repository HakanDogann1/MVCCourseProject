using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            var values = contentManager.TGetList();
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var values = contentManager.TGetFilterList(x=>x.HeadingID == id);
            return View(values);
        }

    }
}