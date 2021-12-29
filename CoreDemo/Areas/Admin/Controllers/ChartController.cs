using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            using (var c = new Context())
            {
                list = c.Categories.Select(x => new CategoryClass
                {
                    categoryName = x.CategoryName,
                    categoryCount = x.Blogs.Count()
                }).ToList();
            }          
            return Json(new { jsonlist = list });
        }
    }
}
