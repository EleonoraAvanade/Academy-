using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Factory
{
    public class Alloggio : ICategoria
    {
        public string Nome { get; set; } = "Alloggio";

        public double GetRimborso(Spesa spesa)
        {
            return spesa.Importo;
        }
    }
}
