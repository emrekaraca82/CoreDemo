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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About par)
        {
            throw new NotImplementedException();
        }

        public void Delete(About par)
        {
            throw new NotImplementedException();
        }

        public List<About> GetAll()
        {
            return _aboutDal.List();
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(About par)
        {
            throw new NotImplementedException();
        }
    }
}
