using System;
using System.Collections.Generic;
using System.Linq;

namespace Week1.Linq
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
            }
        };


        #endregion


        static void Main(string[] args)
        {
            Console.WriteLine("==== LINQ APPLICATO AGLI OGGETTI ====");

            //SENZA LINQ
            List<Valutazione> valutazioniTiziana = new List<Valutazione>();
            foreach(var valutazione in voti)
            {
                //if(valutazione.NomeStudente == "Tiziana")
                if (valutazione.NomeStudente.Equals("Tiziana"))
                {
                    valutazioniTiziana.Add(valutazione);
                }
            }


            //List<Valutazione> valutazioniTizianaLinq = voti
            //.Where(valutazione => valutazione.NomeStudente.Equals("Tiziana"));
            //.ToList();

            //LINQ CON LAMBDA EXPRESSION
            var valutazioniTizianaLinq = voti
                .Where(valutazione => valutazione.NomeStudente.Equals("Tiziana"));
            //LINQ CON QUERY EXPRESSION
            var valutazioniTizanaQueryExpression =
                from valutazione in voti
                where valutazione.NomeStudente.Equals("Tiziana")
                select valutazione;

            foreach(var valutazione in valutazioniTiziana)
            {
                Console.WriteLine(valutazione);
            }

            foreach(var val in valutazioniTizianaLinq)
            {
                Console.WriteLine(val);
            }
            
            foreach(var val in valutazioniTizanaQueryExpression)
            {
                Console.WriteLine(val);
            }

            //LAMBDA EXPRESSION
            var votiItalianoOrdinati = voti
                .Where(val => val.Materia == Materia.Italiano)
                .OrderBy(val => val.Voto)
                .Select(val => val.Voto);
            //EQUIVALENTE A (IN QUERY EXPRESSION)
            var votiItalianoOrdinatiQE =
                from votazione in voti
                where votazione.Materia == Materia.Italiano
                orderby votazione.Voto
                select votazione.Voto;

            foreach(var votazione in votiItalianoOrdinati)
            {
                Console.WriteLine(votazione);
            }
            Console.WriteLine("-------------");
            foreach(var votazione in votiItalianoOrdinatiQE)
            {
                Console.WriteLine(votazione);
            }

            var soloVoti = voti
                .Where(v => v.Materia == Materia.Matematica)
                .Select(
                v => new DettaglioVoto { 
                    NomeStudente = v.NomeStudente, 
                    Voto = v.Voto 
                });
            //EQUIVALENTE A (CON QUERY EXPRESSION)
            var soloVotiQE =
                from valutazione in voti
                where valutazione.Materia == Materia.Matematica
                select new DettaglioVoto
                {
                    NomeStudente = valutazione.NomeStudente,
                    Voto = valutazione.Voto
                };
            foreach(var dettaglio in soloVoti)
            {
                Console.WriteLine(dettaglio.NomeStudente + "-" + dettaglio.Voto);
            }

            //LAMBDA EXPRESSION
            var mediaVotiPerStudente = voti
                .GroupBy(v => v.NomeStudente,
                (key, grp) =>
                new Media
                {
                    NomeStudente = key,
                    MediaVoti = grp.Average(v => v.Voto)
                });
            //EQUIVALENTE A QUERY EXPRESSION
            var mediaVotiPerStudenteQE =
                from v in voti
                group v by v.NomeStudente into grp
                select new Media
                {
                    NomeStudente = grp.Key,
                    MediaVoti = grp.Average(v => v.Voto)
                };

            foreach(var media in mediaVotiPerStudente)
            {
                Console.WriteLine($"{media.NomeStudente} - Media voti: {media.MediaVoti}");
            }

            foreach(var media in mediaVotiPerStudenteQE)
            {
                Console.WriteLine($"{media.NomeStudente} - Media voti: {media.MediaVoti}");
            }

            var valutazioniPerMateria = voti.
                GroupBy(v => v.Materia);

            foreach(var votoMateria in valutazioniPerMateria)//ciclare i raggrupamenti
            {
                Console.WriteLine(votoMateria.Key);
                foreach(var val in votoMateria) //ciclare il singolo raggrupamento
                {
                    Console.WriteLine("\t" + val);
                }
            }

        }
    }
}
