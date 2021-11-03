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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer par)
        {
            _writerDal.Insert(par);
        }

        public void Delete(Writer par)
        {
            _writerDal.Delete(par);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.List();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.List(x => x.WriterId == id);
        }

        public void Update(Writer par)
        {
            _writerDal.Update(par);
        }
    }
}
