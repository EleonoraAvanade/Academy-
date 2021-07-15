using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.EserciziPattern.Entities
{
    class MediumCompany : ICompany
    {
        public int NumEmployees { get; set; }
        public Employee[] Employees { get; set; }

        public string Tipology { get; } = "Medium";

        public MediumCompany()
        {
            //Employees = new Employee[NumEmployees];
        }

        public string PrintDetails()
        {
            return $"Compagnia di medie dimensioni con {NumEmployees} dipendenti";
        }
    }
}
