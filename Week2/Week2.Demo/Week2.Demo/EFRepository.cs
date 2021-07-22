using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly ContextDb ctx;

        public EFRepository(ContextDb context)
        {
            ctx = context;
        }

        public bool Add(T item)
        {
            ctx.Add(item);
            return true;
        }

        public bool GetItem(T item)
        {
            ctx.Set<T>().Find(item);
            return true;
        }

        public bool Remove(T item)
        {
            ctx.Remove(item);
            return true;
        }

        public bool Update(T item)
        {
            ctx.Attach(item);
            return true;
        }
    }
}
