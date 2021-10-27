using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {          
            var blogList = bm.GetBlogListWithCategory();         
            return View(blogList);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.id = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWrtier()
        {
            var values = bm.GetListWithCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog par)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(par);
            if (results.IsValid)
            {
                par.BlogStatus = true;
                par.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                par.WriterId = 1;
                bm.Add(par);
                return RedirectToAction("BlogListByWrtier");
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

        public IActionResult BlogDelete(int id)
        {
            var values = bm.GetById(id);
            bm.Delete(values);
            return RedirectToAction("BlogListByWrtier");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var values = bm.GetById(id);
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View(values);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog par)
        {
            par.BlogStatus = true;
            par.CreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            par.WriterId = 1;
            bm.Update(par);
            return RedirectToAction("BlogListByWrtier");
        }
    }
}
