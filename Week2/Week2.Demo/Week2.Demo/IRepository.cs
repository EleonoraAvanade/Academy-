using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public interface IRepository<T> where T : class
    {

        bool Add(T item);
        bool Remove(T item);
        bool GetItem(T item);
        bool Update(T item);


    }
}
