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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog par)
        {
            _blogDal.Insert(par);
        }

        public void Delete(Blog par)
        {
            _blogDal.Delete(par);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.List();
        }

        public List<Blog> GetLastBlog()
        {
            return _blogDal.List().Take(3).ToList();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.List(x => x.BlogId == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public void Update(Blog par)
        {
            _blogDal.Update(par);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.List(x => x.WriterId == id);
        }
    }
}
