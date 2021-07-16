using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale.Factory
{
    public interface ICategoria
    {
        string Nome { get; set; }

        double GetRimborso(Spesa spesa);
    }
}
