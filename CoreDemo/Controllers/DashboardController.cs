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
    public class DashboardController : Controller
    {     
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            var writerID = wm.GetByFilter(usermail).Select(y => y.WriterId).FirstOrDefault();
            var writer = wm.GetByFilter(usermail).Select(y => new
            {
                writerName = y.WriterName,
                writerImage = y.WriterImage            
            }).FirstOrDefault();
        
            ViewBag.ToplamBlogSayisi = bm.GetAll().Count();
            ViewBag.YazarinBlogSayisi = bm.GetBlogListByWriter(writerID).Count();
            ViewBag.KategoriSayisi = cm.GetAll().Count();
            ViewBag.vname = writer.writerName;
            ViewBag.vimage = writer.writerImage;
            return View();
        }
    }
}
