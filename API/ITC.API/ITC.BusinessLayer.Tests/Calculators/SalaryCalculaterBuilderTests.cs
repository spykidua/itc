using ITC.BusinessLayer.Calculators;
using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.DataAccess.Entities;
using System.Collections.Generic;
using Xunit;

namespace ITC.BusinessLayer.Tests.Calculators
{
    public class SalaryCalculatorBuilderTests
    {
        private readonly ISalaryCalculator _sut; // sut - System under test

        public SalaryCalculatorBuilderTests()
        {
            _sut = new SalaryCalculator();
        }

        [Theory]
        [InlineData(10000, 1000)]
        [InlineData(40000, 11000)]
        public void CalculateAnnualTaxPaid_CalculateAnnualTaxPaidByTheoryValue_ExpectedTaxByTheoryResult(int salary, decimal expected)
        {
            // Arrange
            var taxBands = new List<TaxBand> {
                 new TaxBand {
                    Name = "Band 1",
                    UpperLimit = 5000,
                    LowerLimit = 0,
                    Rate = 0
                 },
                 new TaxBand {
                    Name = "Band 2",
                    UpperLimit = 20000,
                    LowerLimit = 5000,
                    Rate = 20
                 },
                 new TaxBand {
                    Name = "Band 3",
                    UpperLimit = default(int?),
                    LowerLimit = 20000,
                    Rate = 40
                 }
                };

            // Act
            var result = _sut.CalculateAnnualTaxPaid(salary, taxBands);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
