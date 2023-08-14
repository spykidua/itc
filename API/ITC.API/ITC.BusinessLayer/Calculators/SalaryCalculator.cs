using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.DataAccess.Entities;

namespace ITC.BusinessLayer.Calculators
{
    public class SalaryCalculator: ISalaryCalculator
    {
        private const int MonthInYear = 12;

        public decimal CalculateMonthlyTaxPaid(decimal annualTax) => annualTax / MonthInYear;

        public decimal CalculateAnnualTaxPaid(int salary, IEnumerable<TaxBand> taxBands)
        {
            decimal annualTaxPaid = 0m;
            var unprocessedSalaryBalance = salary;

            foreach (var band in taxBands)
            {
                if (unprocessedSalaryBalance <= 0)
                {
                    break;
                }
                var underTax = 0;

                if (!band.UpperLimit.HasValue)
                {
                    underTax = unprocessedSalaryBalance;
                } else if (unprocessedSalaryBalance >= band.LowerLimit && band.UpperLimit.HasValue && unprocessedSalaryBalance >= band.UpperLimit)
                {
                    underTax = band.UpperLimit.Value - band.LowerLimit;

                } else if (unprocessedSalaryBalance >= band.LowerLimit && unprocessedSalaryBalance <= band.UpperLimit)
                {
                    underTax = unprocessedSalaryBalance;
                }

                unprocessedSalaryBalance -= underTax;
                annualTaxPaid += CalculatePureTax(underTax, band.Rate);
            }

            return annualTaxPaid;
        }

        public decimal CalculateNetMonthlySalary(decimal monthlySalary, decimal monthlyTaxPaid) => monthlySalary - monthlyTaxPaid;

        public decimal CalculateNetAnnualSalary(int annualSalary, decimal annualTaxPaid) => annualSalary - annualTaxPaid;

        public decimal CalculateGrossMonthlySalary(int salary) => salary / MonthInYear;

        private decimal CalculatePureTax(int value, int taxPercen) => value * (taxPercen / 100m);
    }
}
