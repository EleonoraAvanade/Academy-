using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public class PresenceHandler : AbstractHandler
    {
        public override double Handle(Employee employee)
        {
            if (employee.Age < 23 && employee.AbsenceRate < 35)
            {
                
                return 200;
            }
            else
            {
                return base.Handle(employee);
            }

        }
    }
}
