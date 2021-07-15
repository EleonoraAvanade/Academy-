using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public class WelfareHandler : AbstractHandler
    {
        public override double Handle(Employee employee)
        {
            if (employee.ProductivityRate >= 35)
            {
                return 400;
            }
            else
            {
                return base.Handle(employee);
            }

        }
    }
}
