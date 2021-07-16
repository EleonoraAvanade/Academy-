using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Factory
{
    public class Vitto : ICategoria
    {
        public string Nome { get; set; } = "Vitto";

        public double GetRimborso(Spesa spesa)
        {
            return spesa.Importo * 0.70;
        }
    }
}
