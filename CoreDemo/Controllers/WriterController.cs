﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
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