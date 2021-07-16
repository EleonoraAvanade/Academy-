using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Handlers
{
    public class CEOHandler : AbstractHandler
    {
        public override Rimborso Handle(Spesa spesa)
        {
            if(spesa.Importo > 1000 && spesa.Importo <= 2500)
            {
                return new Rimborso()
                {
                    Spesa = spesa,
                    Approvato = true,
                    LivelloApprovazione = "CEO",
                    ImportoRimborsato = spesa.Categoria.GetRimborso(spesa)
                };
            }
            return base.Handle(spesa);
        }
    }
}
