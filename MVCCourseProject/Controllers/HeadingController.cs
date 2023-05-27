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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var values = headingManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> list = (from x in categoryManager.TGetList()
                                         select new SelectListItem
                                         {

                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.list = list;

            List<SelectListItem> list2 = (from x in writerManager.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.WriterName + " " + x.WriterSurname,
                                             Value = x.WriterID.ToString()
                                         }).ToList();
            ViewBag.list2 = list2;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
           heading.HeadingDate = DateTime.Parse(DateTime.Now.ToString());
            headingManager.TInsert(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> list = (from x in categoryManager.TGetList()
                                         select new SelectListItem
                                         {

                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.list = list;
            List<SelectListItem> list2 = (from x in writerManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.WriterName + " " + x.WriterSurname,
                                              Value = x.WriterID.ToString()
                                          }).ToList();
            ViewBag.list2 = list2;
            var values = headingManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.TUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var value = headingManager.TGetById(id);
            value.HeadingStatus = false;
            return RedirectToAction("Index");
        }

    }
}