using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            string par = "deneme@gmail.com";
            var values = mm.GetInboxListByWriter(par);
            return View(values);
        }
    }
}
