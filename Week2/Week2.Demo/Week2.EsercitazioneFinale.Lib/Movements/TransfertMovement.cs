using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public class TransfertMovement : IMovement
    {
        public decimal Amount { get; set; }
        public DateTime DateMovement { get; set; }
        public string DestinationBank { get; set; }
        public string OriginBank { get; set; }

        public TransfertMovement(decimal am, DateTime date, string origin, string destination)
        {
            Amount = am;
            DateMovement = date;
            OriginBank = origin;
            DestinationBank = destination;
        }

        public override string ToString()
        {
            return $"[Date: {DateMovement} - Transfert Movement" +
                $"From: {OriginBank} To: {DestinationBank} " +
                $"- Amount: {Amount} EUR]";
        }
    }
}
