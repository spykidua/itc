using ITC.BusinessLayer.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITC.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaxBandController : ControllerBase
    {
        private readonly ITaxBandManager _taxBandManager;

        public TaxBandController(ITaxBandManager taxBandManager)
        {
            _taxBandManager = taxBandManager;
        }

        [HttpGet("tax-bands/check")]
        public async Task<IActionResult> CheckConsistency()
        {
            return Ok(await _taxBandManager.CheckConsistencyAsync());
        }

        [HttpGet("tax-bands")]
        public async Task<IActionResult> GetTaxBands()
        {
            return Ok(await _taxBandManager.GetAllAsync());
        }
    }
}
