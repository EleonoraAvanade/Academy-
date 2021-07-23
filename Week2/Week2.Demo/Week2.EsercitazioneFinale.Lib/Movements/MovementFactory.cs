using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.EsercitazioneFinale.Lib.Movements
{
    public static class MovementFactory
    {
        public static IMovement CreateMovement(MovementData movData)
        {
            switch (movData.Type)
            {
                case MovementType.Cash:
                    return new CashMovement(movData.Amount, movData.DateMovement, movData.Executor);                  
                case MovementType.CreditCard:
                    return new CreditCardMovement(movData.Amount, movData.DateMovement, 
                        movData.CardNumber, movData.CrediCardT);
                case MovementType.Transfert:
                    return new TransfertMovement(movData.Amount, movData.DateMovement, movData.FromBank,
                        movData.ToBank);
                default:
                    throw new ArgumentException("Invalid movement type");
            }
        }
    }
}
