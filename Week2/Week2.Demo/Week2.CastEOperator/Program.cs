using System;

namespace Week2.CastEOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Rombo rombo = new Rombo(13, 10, 10);
            var quadrato = (Quadrato)rombo;

            Quadrato q1 = new Quadrato(10);
            Rombo romboConvertito = q1;

            if(q1 is Rombo)
            {
                Console.WriteLine("Questo quadrato è anche un rombo");
            }
            else
            {
                Console.WriteLine("Questo quadrato non è un rombo");
            }

            //CONVERSIONE SICURA
            if(q1 is Rettangolo)
            {
                Console.WriteLine("Ogni quadrato è anche un rettangolo");
            }

            IShape figuraGeometrica = new Rettangolo(3, 4);
            IShape figuraQuadrato = new Quadrato(4);
            IShape figuraRombo = new Rombo(4, 5, 5);
            //Rombo figuraRombo = new Rombo(4, 5, 5);
            //CONVERSIONE 
            try
            {
                figuraGeometrica = (Rettangolo)figuraQuadrato;
                //figuraGeometrica = (Rettangolo)figuraRombo;
                if(figuraRombo is Rombo)
                {
                    Rombo romboConvertito2 = (Rombo)figuraRombo;
                    if(romboConvertito2.DiagonaleMaggiore == romboConvertito2.DiagonaleMinore)
                    {
                        figuraGeometrica = new Rettangolo(romboConvertito2.Lato, romboConvertito2.Lato);
                    }
                }
            }catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Rombo altroRombo = new Rombo(3, 3, 3);
            //ALTRO METODO DI CAST SICURO
            //var rettangolo = altroRombo as Rettangolo;
            Rettangolo rettangolo = (Rettangolo)altroRombo;
            if ((rettangolo as Rettangolo) == null)
            {
                Console.WriteLine("Cast non valido");
            }

        }
    }
}
