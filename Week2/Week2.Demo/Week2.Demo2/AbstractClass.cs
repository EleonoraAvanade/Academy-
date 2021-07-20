using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public abstract class AbstractClass
    {
        public abstract int Prop1 { get; set; }

        public abstract string MethodA(int value);

        public string MethodB(int value)
        {
            return $"base: {value}";
        }

        public virtual string MethodD()
        {
            return "xxx";
        }

    }
}
