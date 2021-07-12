using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.AcademyWeek1
{
    public class Manager : Person
    {
        public int NumeroSottoposti { get; set; } = 5;

        public override string ToString()
        {
            return base.ToString() + $" Numero sottoposti: {NumeroSottoposti}";
        }
    }
}
