using System;
using Week1.EserciziPattern.Entities;
using Week1.EserciziPattern.Handler;

namespace Week1.EserciziPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero totale di dipendenti");
            var numEmp = Convert.ToInt32(Console.ReadLine());
            while (numEmp < 0)
            {
                Console.WriteLine("Per favore inserisci un numero maggiore di 0");
                numEmp = Convert.ToInt32(Console.ReadLine());
            }
            var company = FactoryCompany.CreateCompany(numEmp);
            Console.WriteLine(company.PrintDetails());
            company.Employees[0] = new Employee
            {
                Name = "Mario",
                LastName = "Rossi",
                Number = "AB123",
                DateOfBirth = new DateTime(1980, 3, 4),
                AbsenceRate = 67,
                HiringDate = new DateTime(2000, 4, 5),
                ProductivityRate = 60
            };
            company.Employees[1] = new Employee
            {
                Name = "Luca",
                LastName = "Bianchi",
                Number = "AB124",
                DateOfBirth = new DateTime(1988, 3, 4),
                AbsenceRate = 6,
                HiringDate = new DateTime(2010, 4, 5),
                ProductivityRate = 25
            };
            

            IHandler prodHandler = new ProductivityHandler();
            IHandler presenceHandler = new PresenceHandler();
            IHandler seniorityHandler = new SeniorityHandler();
            IHandler welfareHandler = new WelfareHandler();

            prodHandler.SetNext(presenceHandler).SetNext(seniorityHandler).SetNext(welfareHandler);

            foreach (var item in company.Employees)
            {
                if(item != null)
                {
                    Console.WriteLine($"Il dipendente {item} ha guadagnato un premio {prodHandler.Handle(item)}");
                }                
            }
        }
    }
}
