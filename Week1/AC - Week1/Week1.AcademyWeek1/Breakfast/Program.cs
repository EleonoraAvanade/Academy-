using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Breakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            Caffe cup = VersaCaffe();
            Console.WriteLine("Il caffè è pronto");

            Task<Uova> uovaTask = FriggiUovaAsync(2);
            Task<Bacon> baconTask = FriggiBaconAsync(3);
            Task<Toast> toastTask = PreparaToastAsync(2);

            Toast toast = await toastTask;
            SpalmaBurro(toast);
            SpalmaMarmellata(toast);
            Console.WriteLine("Il toast è pronto");

            Uova uova = await uovaTask;
            Console.WriteLine("Le uova sono pronte");
            Bacon bacon = await baconTask;
            Console.WriteLine("Il bacon è pronto");

           
            Succo succo = PrendiSucco();
            Console.WriteLine("Succo preso!");

            Console.WriteLine("La colazione è pronta!");
            Console.WriteLine(timer.ElapsedMilliseconds);
            
        }

        private static Succo PrendiSucco()
        {
            Console.WriteLine("Sto prendendo il succo");
            return new Succo();
        }

        private static void SpalmaMarmellata(Toast toast)
        {
            Console.WriteLine("Sto spalmando la marmellata");
        }

        private static void SpalmaBurro(Toast toast)
        {
            Console.WriteLine("Spalma burro");
        }

        //private static Toast PreparaToast(int numeroFette) versione sincrona
        private static async Task<Toast> PreparaToastAsync(int numeroFette)
        {
            {
                for (int i = 0; i < numeroFette; i++)
                {
                    Console.WriteLine("Inserisco una fetta nel tostapane");
                }
                Console.WriteLine("Attendi toast");
                Task.Delay(3000).Wait();
                Console.WriteLine("Toast pronto");
                return new Toast();
            }
        }

        private static async Task<Bacon> FriggiBaconAsync(int fetteBacon)
        //private static Bacon FriggiBacon(int fetteBacon) versione sincrona
        {
            Console.WriteLine($"Sto posizionando {fetteBacon} sulla padella");
            Console.WriteLine("cottura da un lato");
            Task.Delay(3000).Wait();
            for (int i = 0; i < fetteBacon; i++)
            {
                Console.WriteLine("Sto girando le fette");
            }
            Console.WriteLine("Sto cuocendo l'altro lato ");
            Task.Delay(3000).Wait();
            Console.WriteLine("Metti il bacon sul piatto");

            return new Bacon();
        }

        private static async Task<Uova> FriggiUovaAsync(int numeroUova)
        //private static Uova FriggiUova(int numeroUova) versione sincrona
        {
            Console.WriteLine("Sto riscaldando la padella");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Sto rompendo le {numeroUova}");
            Console.WriteLine("Uova in cottura");
            Task.Delay(3000).Wait();
            Console.WriteLine("Metti le uova sul piatto");
            return new Uova();
        }

        private static Caffe VersaCaffe()
        {
            Console.WriteLine("Sto versando il caffè");
            return new Caffe();
        }
    }
}

