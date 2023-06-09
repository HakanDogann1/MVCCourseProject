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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            Context context = new Context();
            var WriterInfoId=context.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterID).FirstOrDefault();
            var values = contentManager.TGetFilterList(x => x.HeadingID == WriterInfoId);
            return View(values);
        }
    }
}