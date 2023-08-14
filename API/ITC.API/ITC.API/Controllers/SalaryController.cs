using ITC.BusinessLayer.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITC.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryManager _salaryManager;

        public SalaryController(ISalaryManager salaryManager)
        {
            _salaryManager = salaryManager;
        }

        [HttpGet("salary/{salary}/calculate-report")]
        public async Task<IActionResult> GetAsync(int salary)
        {
            var salaryReport = await _salaryManager.CalculateSalaryReportAsync(salary);
            
            return Ok(salaryReport);
        }
    }
}
