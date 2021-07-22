using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.SimCard
{
    public interface ICliente
    {
        string Nome { get; set; }
        string Cognome { get; set; }
        DateTime DataNascita { get; set; }
        Sesso Sesso { get; set; }
    }

    public enum Sesso
    {
        M,
        F
    }
}
