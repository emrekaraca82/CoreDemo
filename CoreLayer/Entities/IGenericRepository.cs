using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        List<T> List(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T par);
        void Update(T par);
        void Delete(T par);
    }
}
