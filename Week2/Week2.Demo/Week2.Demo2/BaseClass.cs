using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo2
{
    public class BaseClass 
    {
        public int Value { get; set; } = 12;

        public string Stringa { get; set; } = "prova";

        public BaseClass Coniugato { get; }
        

        public BaseClass() : this (10){
            
            Coniugato = new BaseClass(-this.Value, this.Stringa);
        }

        public BaseClass(int v) : this(v, "")
        {
            Value = v;
        }

        public BaseClass(string s) : this(100, s)
        {
            Stringa = s;
        }

        public BaseClass(int v, string s)
        {
            Value = v;
            Stringa = s;
        }

    }
}
