using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MVCCourseProject.Controllers
{
	[Authorize]
    public class WriterPanelController : Controller
    {
        Admin admin = new Admin();
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
		WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: WriterPanel
        public ActionResult WriterProfile(string p)
        {
			Context context = new Context();
			p = (string)Session["WriterMail"];
			var writerId=context.Writers.Where(x=>x.WriterMail==p).FirstOrDefault();
			var writerProfile = writerManager.TGetById(writerId.WriterID);
            return View(writerProfile);
        }
        public ActionResult MyHeading(string p)
        {
			Context context = new Context();
			p = (string)Session["WriterMail"];
			var writerheadingvalues = context.Writers.Where(x=>x.WriterMail == p).Select(x=>x.WriterID).FirstOrDefault();
            var values = headingManager.TGetFilterList(x => x.WriterID == writerheadingvalues);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
			List<SelectListItem> list = (from x in categoryManager.TGetList()
										 select new SelectListItem
										 {

											 Text = x.CategoryName,
											 Value = x.CategoryID.ToString()
										 }).ToList();
			ViewBag.list = list;
			return View();
        }
		[HttpPost]
		public ActionResult NewHeading(Heading heading)
		{
			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToString());
            heading.WriterID = 4;
            heading.HeadingStatus = true;
			headingManager.TInsert(heading);
			return RedirectToAction("MyHeading");

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
			var values = headingManager.TGetById(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateHeading(Heading heading)
		{
			heading.WriterID = 4;
			headingManager.TUpdate(heading);
			return RedirectToAction("MyHeading");
		}

		public ActionResult DeleteHeading(int id)
		{
			var value = headingManager.TGetById(id);
			value.HeadingStatus = false;
			headingManager.TUpdate(value);
			return RedirectToAction("MyHeading");
		}
		public ActionResult AllHeading(int sayfa =1)
		{
			var values = headingManager.TGetList().ToPagedList(sayfa, 4);
			return View(values);
		}
	}
}