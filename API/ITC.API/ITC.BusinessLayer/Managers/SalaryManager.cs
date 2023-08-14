using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.BusinessLayer.Managers.Interfaces;
using ITC.BusinessLayer.Models;
using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces;
using ITC.DataAccess.Interfaces.Repositories;

namespace ITC.BusinessLayer.Managers
{
    public class SalaryManager : ISalaryManager
    {
        private readonly ISalaryCalculatorBuilder _salaryCalculaterBuilder;
        private readonly IGenericRepository<TaxBand> _taxBandRepository;

        public SalaryManager(ISalaryCalculatorBuilder salaryCalculatorBuilder, IUnitOfWork uow)
        {
            _salaryCalculaterBuilder = salaryCalculatorBuilder;
            _taxBandRepository = uow.GetRepository<TaxBand>();
        }

        public async Task<AnnualSalaryCalculationsModel> CalculateSalaryReportAsync(int salary)
        {
            var taxBands = await _taxBandRepository.GetAsync(sorter: x => x.LowerLimit);
            var grossAnnualSalary = salary;
            var grossMonthlySalary = _salaryCalculaterBuilder.CalculateGrossMonthlySalary(salary);
            var annualTaxPaid = _salaryCalculaterBuilder.CalculateAnnualTaxPaid(salary, taxBands);
            var monthlyTaxPaid = _salaryCalculaterBuilder.CalculateMonthlyTaxPaid(annualTaxPaid);
            var netAnnualSalary = _salaryCalculaterBuilder.CalculateNetAnnualSalary(grossAnnualSalary, annualTaxPaid);
            var netMonthlySalary = _salaryCalculaterBuilder.CalculateNetMonthlySalary(grossMonthlySalary, monthlyTaxPaid);

            return new AnnualSalaryCalculationsModel {
                GrossAnnualSalary = grossAnnualSalary,
                GrossMonthlySalary = grossMonthlySalary,
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = netMonthlySalary,
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = monthlyTaxPaid
            };
        }
    }
}
