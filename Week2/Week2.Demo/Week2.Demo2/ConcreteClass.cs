using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public class ConcreteClass : DerivedClass
    {
        public string Code { get; set; }

        public ConcreteClass() : base(1)
        {

        }

        public ConcreteClass(string code) : base(1)
        {
            Code = code;
        }

        public override int Prop1 { get; set; }

        public override string MethodA(int value)
        {
            throw new NotImplementedException();
        }
    }
}
