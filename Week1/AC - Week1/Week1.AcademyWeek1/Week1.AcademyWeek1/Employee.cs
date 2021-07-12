using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1
{
    public class Employee : Person
    {
        public string Company { get; set; } = "Avanade";

        public override string ToString()
        {
            return $"{FirstName} - {LastName} - {Company}";
        }

        public bool GetPermessoOrario()
        {
            if (Company.Equals("Avanade"))
            {
                return true;
            }
            return false;
        }

    }
}
