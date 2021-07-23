using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public enum CreditCardType
    {
        OTHER,
        VISA,
        MASTERCARD,
        AMEX
    }

    public class CreditCardMovement : IMovement
    {
        public decimal Amount { get; set; }
        public DateTime DateMovement { get; set; }
        public string CardNumber { get; set; }
        public CreditCardType CCType { get; set; }

        public CreditCardMovement(decimal amount, DateTime date, string number, CreditCardType cctype)
        {
            Amount = amount;
            DateMovement = date;
            CardNumber = number;
            CCType = cctype;
        }

        public override string ToString()
        {
            return $"[Date: {DateMovement.ToShortDateString()} CC Movement with {CCType} " +
                $"n. {CardNumber} - Amount: {Amount} EUR]";
        }

    }
}
