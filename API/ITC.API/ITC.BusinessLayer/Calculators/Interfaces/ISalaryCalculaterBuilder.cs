namespace ITC.BusinessLayer.Calculators.Interfaces
{
    public interface ISalaryCalculatorBuilder
    {
        public decimal CalculateMonthlyTaxPaid(decimal annualTax);

        public decimal CalculateAnnualTaxPaid(int salary);

        public decimal CalculateNetMonthlySalary(decimal monthlySalary, decimal monthlyTaxPaid);

        public decimal CalculateNetAnnualSalary(int annualSalary, decimal annualTaxPaid);

        public decimal CalculateGrossMonthlySalary(int salary);
    }
}