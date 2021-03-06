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
        MessageTwoManager mm = new MessageTwoManager(new EfMessageTwoDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerID = wm.GetByFilter(usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            ViewBag.YazarMesajSayısı = mm.GetInboxListByWriter(writerID).Count();
            return View(values);
        }
    }
}
