using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.ChainPattern.Handler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler); //Metodo per settare l'anello successivo della catena
        string Handle(string request); //Metodo che risolve la richiesta
    }
}
