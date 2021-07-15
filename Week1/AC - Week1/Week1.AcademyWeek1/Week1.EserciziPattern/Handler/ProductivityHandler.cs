using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern.Handler
{
    public class ProductivityHandler : AbstractHandler
    {
        public override double Handle(Employee employee)
        {
            if (employee.Age < 23 && employee.ProductivityRate > 70)
            {
                return 100;
            }
            else
            {
                return base.Handle(employee);
            }

        }
    }
}
