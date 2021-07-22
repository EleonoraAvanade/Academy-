using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class RepositoryMock<T>  : IRepository<T> where T : class
    {
        private IList<T> list = new List<T>();
        public bool Add(T item)
        {
            list.Add(item);
            return true;
        }

        public bool GetItem(T item)
        {
            return list.Contains(item);
        }

        public bool Remove(T item)
        {
            list.Remove(item);
            return true;
        }

        public bool Update(T item)
        {
            int index = list.IndexOf(item);
            list.RemoveAt(index);
            list.Add(item);
            return true;
        }
    }
}
