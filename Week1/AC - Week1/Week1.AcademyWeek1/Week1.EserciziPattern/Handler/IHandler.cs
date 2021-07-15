using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler); //Metodo per settare l'anello successivo della catena
        double Handle(Employee employee);
    }
}
