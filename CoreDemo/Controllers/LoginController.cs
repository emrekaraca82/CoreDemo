using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer par)
        {
            Context c = new Context();
            var data = c.Writers.FirstOrDefault(x => x.WriterEmail == par.WriterEmail && x.WriterPassword == par.WriterPassword);
            if(data != null)
            {
                HttpContext.Session.SetString("username", par.WriterEmail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
            
        }
    }
}
