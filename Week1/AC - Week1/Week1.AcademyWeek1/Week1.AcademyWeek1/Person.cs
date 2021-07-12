using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        private string _taxCode; //campo
        //Codice fiscale come campo calcolato
        public string TaxCode
        {
            get
            {
                _taxCode = FirstName.Substring(0, 3) +
                      LastName.Substring(0, 3) + BirthDay.Year;
                return _taxCode;
            }
        }

        private double Stipendio { get { return 1200.56; } }

        public string GetInfoPersona()
        {
            string infoPersona = $"Tax Code: {_taxCode} - Stipendio: {Stipendio}";
            Console.WriteLine(TaxCode);
            Console.WriteLine(_taxCode);
            return infoPersona;
        }

        //overload
        public string GetInfoPersona(string value)
        {
            return $"Nuova info: {value}";
        }

        public override string ToString()
        {
            return GetInfoPersona();
        }

    }
}
