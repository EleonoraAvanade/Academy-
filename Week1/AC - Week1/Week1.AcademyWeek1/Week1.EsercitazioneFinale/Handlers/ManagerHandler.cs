using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Handlers
{
    public class ManagerHandler : AbstractHandler
    {
        public override Rimborso Handle(Spesa spesa)
        {
            if(spesa.Importo > 0 && spesa.Importo <= 400)
            {
                return new Rimborso()
                {
                    Spesa = spesa,
                    Approvato = true,
                    LivelloApprovazione = "Manager",
                    ImportoRimborsato = spesa.Categoria.GetRimborso(spesa)
                };
            }
            else
            {
                return base.Handle(spesa);
            }
        }

    }
}
