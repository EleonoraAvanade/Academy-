using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class PersonResponse
    { 
        public bool Success { get; set; }
        public string Errore { get; set; }
        public Person ReturnedValue { get; set; }
    }
}
