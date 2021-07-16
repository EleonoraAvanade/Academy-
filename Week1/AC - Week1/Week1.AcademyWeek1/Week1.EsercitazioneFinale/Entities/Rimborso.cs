using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Handlers;

namespace Week1.EsercitazioneFinale.Entities
{
    public class Rimborso
    {
        public Spesa Spesa { get; set; }
        public double ImportoRimborsato { get; set; }
        public bool Approvato { get; set; }
        public string LivelloApprovazione { get; set; }

        //METODO DI ELABORAZIONE DEI RIMBORSI
        public static List<Rimborso> ElaborazioneRimborsi(IEnumerable<Spesa> spese)
        {
            List<Rimborso> rimborsi = new List<Rimborso>();

            var managerHandler = new ManagerHandler();
            var opHandler = new OPMHandler();
            var ceoHandler = new CEOHandler();

            managerHandler.SetNext(opHandler).SetNext(ceoHandler);

            foreach(var spesa in spese)
            {
                var rimborso = managerHandler.Handle(spesa);
                if(rimborso == null)
                {
                    rimborso = new Rimborso()
                    {
                        Spesa = spesa,
                        Approvato = false
                    };
                }
                rimborsi.Add(rimborso);
            }

            return rimborsi;
        }

        //STAMPA
        public static void SaveToFile(string fileName, IEnumerable<Rimborso> rimborsi)
        {
            try
            {
                using(StreamWriter writer = File.CreateText($@"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1\{fileName}.txt"))
                {
                    foreach(var rimborso in rimborsi)
                    {
                        string dati = $"{rimborso.Spesa.Data.ToShortDateString()};" +
                            $"{rimborso.Spesa.Categoria.Nome};{rimborso.Spesa.Descrizione};";
                        if (rimborso.Approvato)
                        {
                            dati += $"APPROVATA;{rimborso.LivelloApprovazione};{rimborso.ImportoRimborsato}";
                        }
                        else
                        {
                            dati += $"RESPINTA;-;-";
                        }
                        writer.WriteLine(dati);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
