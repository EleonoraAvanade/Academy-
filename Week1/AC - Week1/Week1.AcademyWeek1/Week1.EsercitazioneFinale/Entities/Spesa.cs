using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EsercitazioneFinale.Factory;

namespace Week1.EsercitazioneFinale.Entities
{
    public class Spesa
    {
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public ICategoria Categoria { get; set; }

        //LOAD
        public static IEnumerable<Spesa> GetSpese(string fileName)
        {
            List<Spesa> spese = new List<Spesa>();
            FactoryCategoria factory = new FactoryCategoria();
            try
            {
                using (StreamReader reader = File.OpenText($@"C:\Users\AntoniaSacchitella\Desktop\Academy\Week1\{fileName}.txt"))
                {
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        string[] datiSpesa = line.Split(";");
                        Spesa spesa = new Spesa()
                        {
                            Data = DateTime.Parse(datiSpesa[0]),
                            Categoria = factory.GetCategoria(datiSpesa[1]),
                            Descrizione = datiSpesa[2],
                            Importo = double.Parse(datiSpesa[3])
                        };
                        spese.Add(spesa);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return spese;
        }
    }
}
