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

            return await Task.FromResult(new AnnualSalaryCalculationsModel {
                GrossAnnualSalary = salary,
                GrossMonthlySalary = _salaryCalculaterBuilder.CalculateGrossMonthlySalary(salary),
                NetAnnualSalary = _salaryCalculaterBuilder.CalculateNetAnnualSalary(salary),
                NetMonthlySalary = _salaryCalculaterBuilder.CalculateNetMonthlySalary(salary),
                AnnualTaxPaid = _salaryCalculaterBuilder.CalculateAnnualTaxPaid(salary),
                MonthlyTaxPaid = _salaryCalculaterBuilder.CalculateMonthlyTaxPaid(salary)
            });
        }

        private object FindTaxBandForSallary(int salary)
        {
            throw new NotImplementedException();
        }
    }
}
