using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public class SeniorityHandler : AbstractHandler
    {
        public override double Handle(Employee employee)
        {
            if (employee.Seniority > 43)
            {
                return 300;
            }
            else
            {
                return base.Handle(employee);
            }


        }
    }
}
