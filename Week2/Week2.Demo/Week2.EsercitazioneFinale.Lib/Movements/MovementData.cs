using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public enum MovementType
    {
        Cash,
        Transfert,
        CreditCard
    }
    public class MovementData
    {
        public MovementType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateMovement { get; set; }
        public string FromBank { get; set; }
        public string ToBank { get; set; }
        public string Executor { get; set; }
        public string CardNumber { get; set; }
        public CreditCardType CrediCardT { get; set; }

    }
}
