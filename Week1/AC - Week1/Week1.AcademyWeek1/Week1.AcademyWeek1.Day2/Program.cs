using System;

namespace Week1.AcademyWeek1.Day2
{
    class Program
    {
        //Definizione delegate
        delegate int Somma(int primoNumero, int secondoNumero);
        static void Main(string[] args)
        {
            //Utilizzo del delgate
            Somma somma = new Somma(Funzionalita.MySum);
            Somma somma2 = new Somma(Funzionalita.ReturnZero);

            int risultato = somma(1, 2);
            int ris = Funzionalita.MySum(1, 2);

            int risul = somma2(3, 5);

            Console.WriteLine("Risultato: {0} - {1} - {2}", risultato, ris, risul);
            Console.Clear();

            Funzionalita.DemoEventi();

        }
    }
}
