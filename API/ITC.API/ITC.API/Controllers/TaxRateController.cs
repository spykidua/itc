using ITC.BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRateController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<TaxBandModel> {
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
                UpperLimit = 20000,
                LowerLimit = 5000,
                Rate = 40
             }
            });
        }
    }
}
