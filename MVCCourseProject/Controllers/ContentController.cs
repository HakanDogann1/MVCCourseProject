using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            var values = contentManager.TGetList();
            return View(values);
        }
        Context Context = new Context();
        public ActionResult GetAllContent(string p)
        {
            var values = (from x in Context.Contents select x);
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y=>y.ContentValue.Contains(p));
            }
           
                return View(values.ToList());
           
        }
        public ActionResult ContentByHeading(int id)
        {
            var values = contentManager.TGetFilterList(x=>x.HeadingID == id);
            return View(values);
        }

    }
}