using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.BusinessLayer.Managers.Interfaces;
using ITC.BusinessLayer.Models;

namespace ITC.BusinessLayer.Managers
{
    public class SalaryManager : ISalaryManager
    {
        private readonly ISalaryCalculatorBuilder _salaryCalculaterBuilder;

        public SalaryManager(ISalaryCalculatorBuilder salaryCalculatorBuilder)
        {
            _salaryCalculaterBuilder = salaryCalculatorBuilder;
        }

        public async Task<AnnualSalaryCalculationsModel> CalculateSalaryReportAsync(int salary)
        {
            var grossAnnualSalary = salary;
            var grossMonthlySalary = _salaryCalculaterBuilder.CalculateGrossMonthlySalary(salary);
            var annualTaxPaid = _salaryCalculaterBuilder.CalculateAnnualTaxPaid(salary);
            var monthlyTaxPaid = _salaryCalculaterBuilder.CalculateMonthlyTaxPaid(annualTaxPaid);
            var netAnnualSalary = _salaryCalculaterBuilder.CalculateNetAnnualSalary(grossAnnualSalary, annualTaxPaid);
            var netMonthlySalary = _salaryCalculaterBuilder.CalculateNetMonthlySalary(grossMonthlySalary, monthlyTaxPaid);

            return await Task.FromResult(new AnnualSalaryCalculationsModel {
                GrossAnnualSalary = grossAnnualSalary,
                GrossMonthlySalary = grossMonthlySalary,
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = netMonthlySalary,
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = monthlyTaxPaid
            });
        }
    }
}
