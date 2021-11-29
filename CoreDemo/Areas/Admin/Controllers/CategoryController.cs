using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetAll().ToPagedList(page,pageSize:10);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category par )
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(par);
            if (results.IsValid)
            {
                par.CategoryStatus = true;
                par.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());            
                cm.Add(par);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = cm.GetById(id);
            if (value.CategoryStatus == true)
            {
                value.CategoryStatus = false;
            }
            else
            {
                value.CategoryStatus = true;
            }
            cm.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category par)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(par);
            if (results.IsValid)
            {
                par.CategoryStatus = true;
                cm.Update(par);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
