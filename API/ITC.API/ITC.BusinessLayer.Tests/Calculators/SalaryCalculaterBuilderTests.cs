using FakeItEasy;
using ITC.BusinessLayer.Calculators;
using ITC.BusinessLayer.Calculators.Interfaces;
using Xunit;

namespace ITC.BusinessLayer.Tests.Calculators
{
    public class SalaryCalculatorBuilderTests
    {
        private readonly ISalaryCalculatorBuilder _sut; // sut - System under test

        public SalaryCalculatorBuilderTests()
        {
            _sut = new SalaryCalculatorBuilder();
        }

        [Theory]
        [InlineData(10000, 1000)]
        [InlineData(40000, 11000)]
        public void CalculateAnnualTaxPaid_CalculateAnnualTaxPaidByTheoryValue_ExpectedTaxByTheoryResult(int salary, decimal expected)
        {
            // Arrange

            // Act
            var result = _sut.CalculateAnnualTaxPaid(salary);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
