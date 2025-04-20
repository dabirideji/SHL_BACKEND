using Microsoft.AspNetCore.Mvc;
using SHL.Domain.Models;

namespace SHL.IdentityServer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeUserController : ControllerBase
    {

        private readonly ILogger<FakeUserController> _logger;
        private readonly Application.Interfaces.GenericRepositoryPattern.IUnitOfWork _unitOfWork;

        public FakeUserController(ILogger<FakeUserController> logger,SHL.Application.Interfaces.GenericRepositoryPattern.IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork=unitOfWork;
        }

      
        [HttpGet("Seed-Fake-User")]
        public IEnumerable<FakeUser> GetFakeUser()
        {
            var fakeUserRepo=_unitOfWork.Set<FakeUser>();

            FakeUser fakeUser = new FakeUser();
            fakeUser.Email = "dabirideji@fakeUser.com";
            fakeUser.Name = "Dabiiri Deji";
            fakeUser.CreatedAt = DateTime.Now;
            fakeUser.UpdatedAt = DateTime.MinValue;
            fakeUserRepo.AddAsync(fakeUser);
            _unitOfWork.SaveChanges(true);

            var fakeUsers = fakeUserRepo.ToList();
            Console.WriteLine(fakeUsers);
            return fakeUsers;
        }
    }
}