using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T par);
        void Update(T par);
        void Delete(T par);
        List<T> GetAll();
        T GetById(int id);
       
    }
}
