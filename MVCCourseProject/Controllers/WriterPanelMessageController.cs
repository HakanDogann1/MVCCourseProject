using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        bool read = false;
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
		MessageValidator validationRules = new MessageValidator();
		public ActionResult Inbox()
		{
			var values = messageManager.TGetFilterList(x => x.ReceiverMail == "gizem@gmail.com");
			return View(values);
		}
		public ActionResult Index()
        {
            return View();
        }
		public ActionResult SendBox()
		{
			var values = messageManager.TGetFilterList(x => x.SenderMail == "gizem@gmail.com");
			return View(values);
		}
		public PartialViewResult PartialMenu()
		{
			return PartialView();
		}
        public ActionResult Read()
        {
            var values = messageManager.TGetByReadMessage();
            return View(values);
        }
        public ActionResult Unread()
        {
            var values = messageManager.TGetByUnreadMessage();
            if (values != null)
            {
                ViewBag.Null = true;
                return View(values);
            }
            else
            {
                ViewBag.Null = false;
                return View();
            }

        }
        public ActionResult GetInboxMessageDetails(int id)
        {

            read = true;
            var values = messageManager.TGetById(id);
            values.Read = true;
            messageManager.TUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.TGetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ValidationResult validationResult = validationRules.Validate(message);
            if (validationResult.IsValid)
            {
                message.SenderMail = "gizem@gmail.com";
                messageManager.TInsert(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }

    }
}