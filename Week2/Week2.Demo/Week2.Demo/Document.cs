using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Demo
{
    public class Document
    {
        public int IdNumber;

        public Document(int idNumber)
        {
            IdNumber = idNumber;
        }

        public override string ToString()
        {
            return "N. Documento " + IdNumber;
        }
    }
}
