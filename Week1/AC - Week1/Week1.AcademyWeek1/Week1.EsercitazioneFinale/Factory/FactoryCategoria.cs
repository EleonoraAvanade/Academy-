using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.EsercitazioneFinale.Factory
{
    public class FactoryCategoria
    {
        public ICategoria GetCategoria(string value)
        {
            ICategoria categoria = null;
            switch (value)
            {
                case "Viaggio":
                    categoria = new Viaggio();
                    break;
                case "Vitto":
                    categoria = new Vitto();
                    break;
                case "Alloggio":
                    categoria = new Alloggio();
                    break;
                case "Altro":
                    categoria = new Altro();
                    break;
                default:
                    break;
            }

            return categoria;
        }

    }
}
