using ITC.BusinessLayer.Models;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Managers.Interfaces
{
    public interface ISalaryManager
    {
        Task<AnnualSalaryCalculationsModel> CalculateSalaryReportAsync(int salary);
    }
}