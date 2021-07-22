using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.SimCard
{
    public class ClientePrivato : ICliente
    {
        public string Nome { get; set ; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public Sesso Sesso { get; set; }

        private int Age { get { return (DateTime.Today.Year - DataNascita.Year); } }

        public ClientePrivato(string nome, string cognome, DateTime dataNascita, Sesso sesso)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Sesso = sesso;
        }

        public bool IsYoung() => Age > 30 ? true : false;

        public static explicit operator ClientePrivato(ClienteBusiness cb)
        {
            return new ClientePrivato(cb.Nome, cb.Cognome, cb.DataNascita, cb.Sesso);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Dati anagrafici cliente: \n");
            sb.Append($"{Nome} \t {Cognome} \t {DataNascita.ToShortDateString()} \t Sesso: {Sesso}");
            return sb.ToString();
        }

    }
}
