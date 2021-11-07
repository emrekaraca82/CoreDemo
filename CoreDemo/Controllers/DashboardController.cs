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
    public class DashboardController : Controller
    {     
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            ViewBag.ToplamBlogSayisi = bm.GetAll().Count();
            ViewBag.YazarinBlogSayisi = bm.GetBlogListByWriter(1).Count();
            ViewBag.KategoriSayisi = cm.GetAll().Count();
            return View();
        }
    }
}
