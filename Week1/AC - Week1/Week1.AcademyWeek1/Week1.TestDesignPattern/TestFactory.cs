using System;
using Week1.EserciziPattern;
using Week1.EserciziPattern.Entities;
using Xunit;

namespace Week1.TestDesignPattern
{
    public class TestFactory
    {
        [Fact]
        public void TestSmallCompany()
        {
            //ARRANGE
            int numEmployee = 18;

            //ACT
            ICompany company = FactoryCompany.CreateCompany(numEmployee);

            //ASSERT
            Assert.True(company.Employees.Length == 18);
            Assert.Equal("Small", company.Tipology);

        }
    }
}
