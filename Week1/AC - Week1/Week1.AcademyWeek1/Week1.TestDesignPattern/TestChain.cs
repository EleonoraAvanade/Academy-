using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.EserciziPattern;
using Week1.EserciziPattern.Entities;
using Week1.EserciziPattern.Handler;
using Xunit;

namespace Week1.TestDesignPattern
{
    public class TestChain
    {
        [Fact]
        public void TestHandleProductivity()
        {
            //ARRANGE
            ICompany company = FactoryCompany.CreateCompany(2);
            company.Employees[0] = new Employee
            {
                Name = "Mario",
                LastName = "Rossi",
                DateOfBirth = new DateTime(1990, 5, 7),
                ProductivityRate = 60
            };
            company.Employees[1] = new Employee
            {
                DateOfBirth = new DateTime(2000, 7, 15),
                ProductivityRate = 80
            };
            var prodHandle = new ProductivityHandler();

            //ACT
            double premio = prodHandle.Handle(company.Employees[0]);
            double premio2 = prodHandle.Handle(company.Employees[1]);

            //ASSERT
            Assert.Equal(0, premio);
            Assert.Equal(100, premio2);
        }

        [Fact]
        public void TestChainHandlers()
        {
            //ARRANGE
            ICompany company = FactoryCompany.CreateCompany(4);
            company.Employees[0] = new Employee
            {
                DateOfBirth = new DateTime(2000, 4, 7),
                ProductivityRate = 85,
                AbsenceRate = 56,
                HiringDate = new DateTime(2008, 6, 7)
            };
            company.Employees[1] = new Employee
            {
                DateOfBirth = new DateTime(2000, 4, 7),
                ProductivityRate = 45,
                AbsenceRate = 30,
                HiringDate = new DateTime(2008, 6, 7)
            };
            company.Employees[2] = new Employee
            {
                DateOfBirth = new DateTime(1960, 4, 7),
                ProductivityRate = 45,
                AbsenceRate = 30,
                HiringDate = new DateTime(1977, 6, 7)
            };
            company.Employees[3] = new Employee
            {
                DateOfBirth = new DateTime(1995, 4, 7),
                ProductivityRate = 80,
                AbsenceRate = 90,
                HiringDate = new DateTime(2018, 6, 7)
            };

            var prodHandler = new ProductivityHandler();
            var senHandler = new SeniorityHandler();
            var presHandler = new PresenceHandler();
            var welfareHandler = new WelfareHandler();

            prodHandler.SetNext(presHandler).SetNext(senHandler).SetNext(welfareHandler);

            //ACT
            double premio1 = prodHandler.Handle(company.Employees[0]);
            double premio2 = prodHandler.Handle(company.Employees[1]);
            double premio3 = prodHandler.Handle(company.Employees[2]);
            double premio4 = prodHandler.Handle(company.Employees[3]);

            //ASSERT
            Assert.Equal(100.0, premio1);
            Assert.Equal(200.0, premio2);
            Assert.Equal(300.0, premio3);
            Assert.Equal(400.0, premio4);

        }

    }
}
