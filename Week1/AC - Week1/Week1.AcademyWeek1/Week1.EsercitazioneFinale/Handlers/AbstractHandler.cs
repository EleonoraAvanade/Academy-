using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Handlers
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _next;

        public virtual Rimborso Handle(Spesa spesa)
        {
            if(_next != null)
            {
                return _next.Handle(spesa);
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            _next = handler;
            return handler;
        }
    }
}
