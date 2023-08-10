namespace ITC.BusinessLayer.Calculators.Interfaces
{
    public interface ISalaryCalculatorBuilder
    {
        public decimal CalculateMonthlyTaxPaid(int salary);

        public decimal CalculateAnnualTaxPaid(int salary);

        public decimal CalculateNetMonthlySalary(int salary);

        public decimal CalculateNetAnnualSalary(int salary);

        public decimal CalculateGrossMonthlySalary(int salary);
    }
}