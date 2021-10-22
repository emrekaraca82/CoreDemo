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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category par)
        {
            _categoryDal.Insert(par);
        }

        public void Delete(Category par)
        {
            _categoryDal.Delete(par);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public void Update(Category par)
        {
            _categoryDal.Update(par);
        }
    }
}
