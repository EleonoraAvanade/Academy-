using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.EserciziPattern.Entities
{
    class MultinationalCompany : ICompany
    {
        public int NumEmployees { get; set; }
        public Employee[] Employees { get; set; }

        public string Tipology { get; } = "Multinational";

        public MultinationalCompany()
        {
            Employees = new Employee[NumEmployees];
        }

        public string PrintDetails()
        {
            return $"Multinazionale con {NumEmployees} dipendenti";
        }
    }
}
