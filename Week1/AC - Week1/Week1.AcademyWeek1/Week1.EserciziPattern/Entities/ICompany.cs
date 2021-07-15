using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.EserciziPattern.Entities
{
    public interface ICompany
    {
        public int NumEmployees { get; set; }
        public string Tipology { get; }

        public Employee[] Employees { get; set; }

        string PrintDetails();
    }
}
