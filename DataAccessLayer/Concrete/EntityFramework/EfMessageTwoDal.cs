using CoreLayer.Entities.Repositories;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageTwoDal : GenericRepositoryBase<MessageTwo, Context>, IMessageTwoDal
    {
        public List<MessageTwo> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.MessageTwos.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
