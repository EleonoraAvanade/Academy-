using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Handlers
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Rimborso Handle(Spesa spesa);
    }
}
