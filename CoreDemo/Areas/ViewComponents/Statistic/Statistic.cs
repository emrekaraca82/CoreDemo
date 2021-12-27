using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.ViewComponents.Statistic
{
    public class Statistic : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = bm.GetAll().Count();
            ViewBag.mesajCount = c.Contacts.Count();
            ViewBag.yorumCount = c.Comments.Count();
            return View();
        }
    }
}
