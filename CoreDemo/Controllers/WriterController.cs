using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage par)
        {
            Writer wr = new Writer();
            if(par.WriterImage != null)
            {
                var extension = Path.GetExtension(par.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImage/",
                    newImageName);
                var stream = new FileStream(location, FileMode.Create);
                par.WriterImage.CopyTo(stream);
                wr.WriterImage = newImageName;
            }
            wr.WriterAbout = par.WriterAbout;
            wr.WriterEmail = par.WriterEmail;
            wr.WriterName = par.WriterName;
            wr.WriterPassword = par.WriterPassword;
            wr.WriterStatus = true;
            wm.Add(wr);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = wm.GetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer par)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(par);
            if (results.IsValid)
            { 
                wm.Update(par);
                return RedirectToAction("Index", "Dashboard");

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

        public PartialViewResult WriterNavbar()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }




    }
}
