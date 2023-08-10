using ITC.BusinessLayer.Models;

namespace ITC.BusinessLayer.Managers.Interfaces
{
    public interface ISalaryManager
    {
        Task<AnnualSalaryCalculationsModel> CalculateSalaryReportAsync(int salary);
    }
}