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
    public class MessageTwoManager : IMessageTwoService
    {
        IMessageTwoDal _messageTwoDal;
        public MessageTwoManager(IMessageTwoDal messageTwoDal)
        {
            _messageTwoDal = messageTwoDal;
        }

        public void Add(MessageTwo par)
        {
            _messageTwoDal.Insert(par);
        }

        public void Delete(MessageTwo par)
        {
            _messageTwoDal.Delete(par);
        }

        public List<MessageTwo> GetAll()
        {
            return _messageTwoDal.List();
        }

        public MessageTwo GetById(int id)
        {
            return _messageTwoDal.Get(x => x.MessageID == id);
        }

        public List<MessageTwo> GetInboxListByWriter(int id)
        {
            return _messageTwoDal.GetListWithMessageByWriter(id);
        }

        public void Update(MessageTwo par)
        {
            _messageTwoDal.Update(par);
        }
    }
}
