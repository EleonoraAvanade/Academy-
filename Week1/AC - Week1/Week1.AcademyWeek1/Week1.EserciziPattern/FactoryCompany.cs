using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern.Entities;

namespace Week1.EserciziPattern
{
    public static class FactoryCompany
    {
        public static ICompany CreateCompany(int numEmployees)
        {
            ICompany company;
            if (numEmployees > 0 && numEmployees <= 20)
            {
                company = new SmallCompany()
                {
                    NumEmployees = numEmployees
                };
            }
            else if (numEmployees <= 100)
            {
                company = new MediumCompany()
                {
                    NumEmployees = numEmployees
                };
                
            }
            else if (numEmployees <= 500)
            {
                company = new BigCompany()
                {
                    NumEmployees = numEmployees
                };
            }
            else
            {
                company = new MultinationalCompany()
                {
                    NumEmployees = numEmployees
                };
            }
            company.Employees = new Employee[numEmployees];
            return company;
        }
    }
}
