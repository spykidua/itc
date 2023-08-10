using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Models
{
    public class AnnualSalaryCalculationsModel
    {
        public decimal GrossAnnualSalary { get; set; }

        public decimal GrossMonthlySalary { get; set; }

        public decimal NetAnnualSalary { get; set; }

        public decimal NetMonthlySalary { get; set; }

        public decimal AnnualTaxPaid { get; set; }

        public decimal MonthlyTaxPaid { get; set; }

    }
}
