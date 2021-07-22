using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.SimCard
{
    public static class OperazioniSim
    {
        public static void EseguiChiamata(this Sim sim, int minuti)
        {
            Console.WriteLine("Chiamata in corso");
            //10 minuti -> offerta
            //20 minuti -> chiamata
            if(sim.OffertaSim != null )
            {
                var minutiDopoChiamata = sim.OffertaSim.Minuti - minuti;
                if (minutiDopoChiamata < 0)
                {
                    sim.OffertaSim.Minuti = 0;
                    sim.CreditoResiduo -= (0.19 * Math.Abs(minutiDopoChiamata));
                }              
            }
            else
            {
                sim.CreditoResiduo -= (0.19 * minuti);
            }
            Console.WriteLine("Chiamata terminata");
        }

        public static string VerificaCredito(this Sim sim)
        {
            return $"Il tuo credito residuo è: {sim.CreditoResiduo} euro";
        }

        public static string VerificaOfferta(this Sim sim)
        {
            if(sim.OffertaSim != null)
            {
                return $"La tua offerta prevede {sim.OffertaSim.Minuti} minuti," +
                $" {sim.OffertaSim.Sms} SMS e {sim.OffertaSim.Giga} GB";
            }
            else
            {
                return "Nessuna offerta attiva";
            }
            
        }

    }
}
