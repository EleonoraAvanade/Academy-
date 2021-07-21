using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2.Linq
{
    class Program
    {
        #region DATI DI PROVA
        static List<Valutazione> voti = new List<Valutazione>
        {
            new Valutazione
            {
                NomeStudente = "Franco",
                DataValutazione = new DateTime(2021, 7, 15),
                Materia = Materia.Geografia,
                Voto = 7
            },
            new Valutazione
            {
                NomeStudente = "Franco",
                DataValutazione = new DateTime(2021, 7, 10),
                Materia = Materia.Italiano,
                Voto = 8
            },
            new Valutazione
            {
                NomeStudente = "Paolo",
                DataValutazione = new DateTime(2021, 7, 11),
                Materia = Materia.Matematica,
                Voto = 4
            },
            new Valutazione
            {
                NomeStudente = "Gloria",
                DataValutazione = new DateTime(2021, 7, 12),
                Materia = Materia.Storia,
                Voto = 6
            },
            new Valutazione
            {
                NomeStudente = "Luigi",
                DataValutazione = new DateTime(2021, 7, 12),
                Materia = Materia.Storia,
                Voto = 8
            },
            new Valutazione
            {
                NomeStudente = "Tiziana",
                DataValutazione = new DateTime(2021, 7, 14),
                Materia = Materia.Matematica,
                Voto = 9
            },
            new Valutazione
            {
                NomeStudente = "Tiziana",
                DataValutazione = new DateTime(2021, 7, 15),
                Materia = Materia.Italiano,
                Voto = 5
            },
            new Valutazione
            {
                NomeStudente = "Antonia",
                DataValutazione = new DateTime(2021, 7, 21),
                Materia= Materia.Matematica,
                Voto = 10
            }
        };
        #endregion

        static void Main(string[] args)
        {
            var soloVotiItaliano = voti
                .Where(voti => voti.Materia == Materia.Italiano)
                .Select(voto => new { Studente = voto.NomeStudente, Voto = voto.Voto}); 

            foreach(var v in soloVotiItaliano)
            {
                Console.WriteLine(v.Studente + " - " + v.Voto);
            }

            var soloVotiItalianoQE =
                from v in voti
                where v.Materia == Materia.Italiano
                select new { Studente = v.NomeStudente, Voto = v.Voto };

            var studente = new { Nome = "Mario", Age = 24, Materia = Materia.Geografia };
            var dipendente = new { Nome = "ABCD", Age = 15, Materia = Materia.Matematica };
            var manager = new { Nome = "Pippo", Age = 25 };
            studente = dipendente;
            //dipendente = manager; ERRORE! A Manager manca la Materia

            var val = voti.GetValutazioniStudentiA();
            foreach(var item in val)
            {
                Console.WriteLine(item);
            }
            
            if (val.AnyValutazione(val.Count()))
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("La lista contiene dei valori");
            }
        }
    }
}
