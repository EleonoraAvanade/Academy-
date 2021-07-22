using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.ComplexNumber
{
    public class NumeroComplessoException : Exception
    {
        public NumeroComplesso PrimoOperatore { get; set; }
        public NumeroComplesso SecondoOperatore { get; set; }

        public NumeroComplessoException() : base()
        {
            //operazioni di salvataggio su file che riportano l'errore
        }

        public NumeroComplessoException(string message) : base(message)
        {
        }

        public NumeroComplessoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
