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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message par)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message par)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            return _messageDal.List();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string par)
        {
            return _messageDal.List(x => x.Receiver == par);
        }

        public void Update(Message par)
        {
            throw new NotImplementedException();
        }
    }
}
