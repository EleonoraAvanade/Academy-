using System;
using Week2.ComplexNumber;

namespace Week2.EsercitazioneComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci parte reale del primo numero complesso");
            double.TryParse(Console.ReadLine(), out double reale);
            Console.WriteLine("Inserisci parte immaginaria del primo numero complesso");
            double.TryParse(Console.ReadLine(), out double immaginaria);
            NumeroComplesso nc = new NumeroComplesso
            {
                Reale = reale,
                Immaginaria = immaginaria
            };
            Console.WriteLine("Secondo numero - Parte reale");
            double.TryParse(Console.ReadLine(), out reale);
            Console.WriteLine("Secondo numero - Parte immaginaria");
            double.TryParse(Console.ReadLine(), out immaginaria);
            NumeroComplesso nc2 = new NumeroComplesso()
            {
                Reale = reale,
                Immaginaria = immaginaria
            };

            Console.WriteLine("Numeri inseriti \n {0} \n {1}", nc, nc2);
            Console.WriteLine("Numeri inseriti \n {0}\n {1}", nc.ToString(Format.Algebrico), nc2.ToString(Format.Algebrico));

            Console.WriteLine(@"Scegli l'operazione + - / *");
            var op = Console.Read();
            NumeroComplesso risultato = new NumeroComplesso();
            switch (op)
            {
                case '+':
                    risultato = nc.Somma(nc2);
                    break;
                case '-':
                    risultato = nc.Differenza(nc2);
                    break;
                case '*':
                    risultato = nc.Moltiplicazione(nc2);
                    break;
                case '/':
                    try
                    {
                        risultato = nc.Divisione(nc2);
                    }catch(NumeroComplessoException ex)
                    {
                        //Console.WriteLine(ex.Message);
                        throw ex;
                    }
                    
                    break;
            }
            Console.WriteLine("Risultato: {0}", risultato.ToString(Format.Parentesi));
            Console.WriteLine("Risultato: {0}", risultato.ToString(Format.Algebrico));

        }
    }
}
