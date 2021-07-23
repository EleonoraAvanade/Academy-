using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public class CashMovement : IMovement
    {
        public decimal Amount { get; set; }
        public DateTime DateMovement { get; set; }
        public string Name { get; set; }

        public CashMovement(decimal amount, DateTime date, string name)
        {
            Amount = amount;
            DateMovement = date;
            Name = name;
        }

        public override string ToString()
        {
            return $"[Data: {DateMovement} Cash Movement by {Name} - Amount: {Amount} EUR]";
        }
    }
}
