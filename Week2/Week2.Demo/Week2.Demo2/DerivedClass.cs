using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public class DerivedClass : AbstractClass, ITest
    {
        public override int Prop1 { get; set; }

        //public DerivedClass() { }

        public DerivedClass(int p)
        {
            Prop1 = p;
        }


        public override string MethodA(int value) => ""; //METODO SOTTOFORMA DI LAMBDA EXPRESSION


        public new string MethodB(int value)
        {
            return $"Value: {value}";
        }

        public int MethodC()
        {
            return 0;
        }
    }
}
