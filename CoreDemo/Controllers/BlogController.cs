using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogDal());

        //IBlogService _blogService;
        //public BlogController(IBlogService blogService)
        //{
        //    _blogService = blogService;
        //}

        public IActionResult Index()
        {
            //var blogList = _blogService.GetAll(); 
            var blogList = bm.GetAll();         
            return View(blogList);
        }
    }
}
