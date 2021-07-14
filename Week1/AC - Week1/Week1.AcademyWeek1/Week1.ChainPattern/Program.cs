using System;
using System.Collections.Generic;
using Week1.ChainPattern.Handler;

namespace Week1.ChainPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chain of Responsibility");

            var monkey = new MonkeyHandler();
            var zebra = new ZebraHandler();
            var lion = new LionHandler();

            //CREO LA CATENA
            monkey.SetNext(zebra).SetNext(lion);
            List<string> food = new List<string> { "Insalata", "Banana", "Pasta", "Bistecca"};
            foreach (var item in food)
            {
                Console.WriteLine($"Chi vuole {item}");
                var result = monkey.Handle(item);
                if(result != null)
                {
                    Console.WriteLine($" \t {result}");
                } else
                {
                    Console.WriteLine($"Nessuno ha mangiato {item}");
                }

            }


        }
    }
}
