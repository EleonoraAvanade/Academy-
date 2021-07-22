using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.SimCard
{
    public class ClienteBusiness : ICliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public Sesso Sesso { get; set; }

        public string IBAN { get; set; }
        public string PIVA { get; set; }

        public ClienteBusiness(string nome, string cognome, DateTime dataNascita, Sesso sesso, string iban, string piva)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Sesso = sesso;
            IBAN = iban;
            PIVA = piva;
        }

        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=== Cliente Business ===");
            sb.AppendLine($"P.IVA {PIVA} - IBAN {IBAN}");
            sb.AppendLine($"{Nome} \t {Cognome} \t {DataNascita.ToShortDateString()}");
            return sb.ToString();
        }
    }
}
