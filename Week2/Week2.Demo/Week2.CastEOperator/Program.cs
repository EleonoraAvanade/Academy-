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

            #region NULLABLE

            Frazione f = null;

            int num = f?.Numeratore ?? 0;
            //equivalente a
            if(f != null)
            {
                num = f.Numeratore;
            }
            else
            {
                num = 0;
            }
            //equivalente
            num = (f != null) ? f.Numeratore : 0;

            Sample s = null;
            Sample s1 = new Sample { StringSample = null };
            Sample s2 = new Sample { StringSample = "prova" };

            var stringUp = s1?.StringSample?.ToUpper() ?? "STRINGA MAIUSCOLA";

            if(s2 != null)
            {
                if(s2.StringSample != null)
                {
                    stringUp = s2.StringSample.ToUpper();
                }
                else
                {
                    s2.StringSample = "STRINGA MAIUSCOLA";
                }
            }
            else
            {
                stringUp = "STRINGA MAIUSCOLA";
            }

            #endregion

        }
    }
}
