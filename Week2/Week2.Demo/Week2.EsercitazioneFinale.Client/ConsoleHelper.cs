using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.EsercitazioneFinale.Lib.Movements;

namespace Week2.EsercitazioneFinale.Client
{
    public static class ConsoleHelper
    {

        public static string GetData(string message)
        {
            Console.WriteLine(message + ": ");
            var value = Console.ReadLine();
            return value;
        }

        public static string BuildMenu(string title, List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine($"=========== {title} ===============");
            Console.WriteLine();

            foreach(var item in menuItems)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.Write("->");
            string command = Console.ReadLine();
            return command;
        }

        internal static IMovement NewMovement()
        {
            Console.Clear();
            Console.WriteLine("---- ADD NEW MOVEMENT ----");
            MovementData movementData = new();
            var amount = GetData("Amount");
            decimal.TryParse(amount, out decimal amt);

            movementData.Amount = amt;
            movementData.DateMovement = DateTime.Now;
            movementData.Type = GetEnum<MovementType>("Type");

            switch (movementData.Type)
            {
                case MovementType.Cash:
                    movementData.Executor = GetData("Executor");
                    break;
                case MovementType.CreditCard:
                    movementData.CrediCardT = GetEnum<CreditCardType>("Credit Card Type");
                    movementData.CardNumber = GetData("Card Number");
                    break;
                case MovementType.Transfert:
                    movementData.FromBank = GetData("From bank");
                    movementData.ToBank = GetData("To Bank");
                    break;
                default:
                    throw new ArgumentException("Invalid type");
            }
            return MovementFactory.CreateMovement(movementData);
        }

        public static T GetEnum<T>(string enumName, T state = default(T)) where T : struct
        {
            string enumLegenda = $"{enumName} [";
            foreach(var item in Enum.GetValues(typeof(T)))
            {
                enumLegenda += item.ToString() + "/";
            }
            enumLegenda += "] > ";

            Console.WriteLine(enumLegenda);
            var value = Console.ReadLine();

            Enum.TryParse<T>(value, true, out T result);

            return result;
        }
    }
}
