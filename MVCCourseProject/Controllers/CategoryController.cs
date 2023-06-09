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
using System.Web.UI.WebControls;

namespace MVCCourseProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryValidator validator = new CategoryValidator();
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        [Authorize]
        public ActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
          
            ValidationResult result = validator.Validate(category); 
            if(result.IsValid)
            {
                categoryManager.TInsert(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        public ActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}