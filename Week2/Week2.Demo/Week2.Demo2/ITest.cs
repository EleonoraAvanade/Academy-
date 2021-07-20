using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public interface ITest
    {
        int Prop1 { get; set; }
        string MethodA(int value);
        string MethodB(int value);
        int MethodC();
    }
}
