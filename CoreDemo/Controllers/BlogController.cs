using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
