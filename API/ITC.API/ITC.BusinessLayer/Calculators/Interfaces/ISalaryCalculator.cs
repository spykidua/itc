using ITC.DataAccess.Entities;

namespace ITC.BusinessLayer.Calculators.Interfaces
{
    public interface ISalaryCalculator
    {
        public decimal CalculateMonthlyTaxPaid(decimal annualTax);

        public decimal CalculateAnnualTaxPaid(int salary, IEnumerable<TaxBand> taxBands);

        public decimal CalculateNetMonthlySalary(decimal monthlySalary, decimal monthlyTaxPaid);

        public decimal CalculateNetAnnualSalary(int annualSalary, decimal annualTaxPaid);

        public decimal CalculateGrossMonthlySalary(int salary);
    }
}