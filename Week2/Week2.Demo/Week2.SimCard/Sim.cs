using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.SimCard
{
    public class Sim
    {
        public string Numero
        {
            get { return Numero; }
            set
            {
                if (value.Length > 10) { 
                    Numero = value.Substring(0, 10); 
                }
                Numero = value;
            }
        }

        public double CreditoResiduo { get; set; }

        public Offerta OffertaSim { get; set; }

        public ICliente Cliente { get; set; }

        public Sim(string numero, double credito, ICliente cliente)
        {
            if(numero.Length > 10)
            {
                Numero = numero.Substring(0, 10);
            }
            else
            {
                Numero = numero;
            }
            CreditoResiduo = credito;
            Cliente = cliente;
        }
        
        public static bool operator +(Sim sim, double importo)
        {
            if(importo > 0)
            {
                sim.CreditoResiduo += importo;
                return true;
            }
            return false;
        }

        //public static Sim operator +(Sim sim, double importo)
        //{
        //    sim.CreditoResiduo += importo;
        //    return sim;
        //}


        public class Offerta
        {
            public string Nome { get; set; }
            public int Giga { get; set; }
            public int Minuti { get; set; }
            public int Sms { get; set; }

            public Offerta(string nome, int gb, int min, int sms)
            {
                Nome = nome;
                Giga = gb;
                Minuti = min;
                Sms = sms;
            }
        }

    }
}
