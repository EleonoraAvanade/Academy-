using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Entities;

namespace Week1.EsercitazioneFinale
{
    public static class Monitoraggio
    {
        public static void HandleNewFile(object sender, FileSystemEventArgs e)
        {
            IEnumerable<Spesa> spese = Spesa.GetSpese("spese");

            //ELABORAZIONE RIMBORSI
            Console.WriteLine("Sto elaborando i rimborsi ... ");

            var rimborsi = Rimborso.ElaborazioneRimborsi(spese);

            //SCRITTURA SU FILE
            Rimborso.SaveToFile("spese_elaborate", rimborsi);

            Console.WriteLine("Fine elaborazione");
        }
    }
}
