using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.EserciziPattern.Entities
{
    class SmallCompany : ICompany
    {
        public int NumEmployees { get; set; }
        public Employee[] Employees { get; set; }

        public string Tipology { get; } = "Small";

        public SmallCompany()
        {
            Employees = new Employee[NumEmployees];
        }

        public string PrintDetails() => $"Piccola compagnia di {NumEmployees} dipendenti";

    }
}
