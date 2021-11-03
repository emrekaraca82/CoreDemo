using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
   
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var values = vm.GetWriterById(1);
            return View(values);
        }
    }
}
