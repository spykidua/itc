using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Calculators
{
    public class SalaryCalculatorBuilder: ISalaryCalculatorBuilder
    {
        private const int MonthInYear = 12;

        public decimal CalculateMonthlyTaxPaid(int salary)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateAnnualTaxPaid(int salary)
        {
            var taxBands = GetTaxBands().OrderBy(x => x.LowerLimit);

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

        private decimal CalculatePureTax(int value, int taxPercen) => value * (taxPercen / 100m);

        public decimal CalculateNetMonthlySalary(int salary)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateNetAnnualSalary(int salary)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateGrossMonthlySalary(int salary)
        {
            return salary / MonthInYear;
        }

        private List<TaxBandModel> GetTaxBands()
        {
            return new List<TaxBandModel> {
             new TaxBandModel {
                Name = "Band 1",
                UpperLimit = 5000,
                LowerLimit = 0,
                Rate = 0
             },
             new TaxBandModel {
                Name = "Band 2",
                UpperLimit = 20000,
                LowerLimit = 5000,
                Rate = 20
             },
             new TaxBandModel {
                Name = "Band 3",
                UpperLimit = default(int?),
                LowerLimit = 20000,
                Rate = 40
             }
            };
        }
    }
}
