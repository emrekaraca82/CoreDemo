using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification par)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification par)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetAll()
        {
           return _notificationDal.List();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification par)
        {
            throw new NotImplementedException();
        }
    }
}
