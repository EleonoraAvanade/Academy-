using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class MySortedList<T> where T : IComparable
    {
        List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public static T Max<T>(IEnumerable<T> list) where T : IComparable
        {
            bool isFirst = true;
            T res = default(T);
            foreach(T item in list)
            {
                if (isFirst)
                {
                    res = item;
                    isFirst = false;
                }
                if (res.CompareTo(item) < 0)
                {
                    res = item;
                }
            }
            return res;
        }
    }
}
