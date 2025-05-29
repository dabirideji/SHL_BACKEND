using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHL.Application.IServices;

namespace SHL.IdentityServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquityCompaniesController : ControllerBase
    {
        private readonly IEStockService eStockService;

        public EquityCompaniesController(IEStockService eStockService)
        {
            this.eStockService = eStockService;
        }
        [HttpGet("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var result=await eStockService.GetCompanies();
            return Ok(result);
        }
    }
}
