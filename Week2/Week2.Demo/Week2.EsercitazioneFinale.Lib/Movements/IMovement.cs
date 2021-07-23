using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public interface IMovement
    {
        decimal Amount { get; set; }
        DateTime DateMovement { get; set; }
    }
}
