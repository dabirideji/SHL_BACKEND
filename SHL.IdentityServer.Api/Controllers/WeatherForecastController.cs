using Microsoft.AspNetCore.Mvc;

namespace SHL.IdentityServer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SHL.Application.Interfaces.GenericRepositoryPattern.IUnitOfWork _unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,SHL.Application.Interfaces.GenericRepositoryPattern.IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork=unitOfWork;
        }

      
        [HttpGet(Name = "GetFakeUser")]
        public IEnumerable<WeatherForecast> GetFakeUser()
        {

            var fakeUserRepo=_unitOfWork.Set<SHL.Domain.Models.FakeUser>();
            var fakeUsers = fakeUserRepo.ToList();
            Console.WriteLine(fakeUsers);


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}