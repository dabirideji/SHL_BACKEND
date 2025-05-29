using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHL.Application.IServices;
using SHL.Application.Repositories;

namespace SHL.IdentityServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IStateRepository stateRepository;
        private readonly ILgaRepository lgaRepository;
        private readonly ICountryRepository countryRepository;

        public LocationController(IStateRepository stateRepository,ILgaRepository lgaRepository,ICountryRepository countryRepository)
        {
            this.stateRepository = stateRepository;
            this.lgaRepository = lgaRepository;
            this.countryRepository = countryRepository;
        }
        [HttpGet("GetCountry")]
        public async Task<IActionResult> GetCountry()
        {
            var result = countryRepository.Get().ToList();
            return Ok(result);
        }
        [HttpGet("GetState/{CountryId}")]
        public async Task<IActionResult> GetState(int CountryId)
        {
            var result= stateRepository.Get().Where(x=>x.CountryId==CountryId).ToList();
            return Ok(result);
        }
        [HttpGet("GetLga/{StateId}")]
        public async Task<IActionResult> GetLga(int StateId)
        {
            var result = lgaRepository.Get().Where(x => x.StateId == StateId).ToList();
            return Ok(result);
        }
    }
}
