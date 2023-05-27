using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager=new ContactManager(new EfContactDal());
        ContactValidator contactValidator=new ContactValidator();
        public ActionResult Index()
        {
            var values = contactManager.TGetList();
            return View(values);
        }
        
        public ActionResult ContactDetails(int id)
        {
            var values = contactManager.TGetById(id);
            return View(values);
        }

        public PartialViewResult PartialMenu()
        {
            Context context = new Context();
            ViewBag.ContactIndex = context.Contacts.Count();
            ViewBag.Inbox = context.Messages.Where(x=>x.ReceiverMail=="Admin@gmail.com").Count();
            ViewBag.SendBox = context.Messages.Where(x => x.SenderMail == "Admin@gmail.com").Count();
            return PartialView();
        }
    }
}