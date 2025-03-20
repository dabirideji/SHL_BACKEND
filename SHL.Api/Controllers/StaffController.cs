using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHL.Api;
using SHL.Application.CQRS.Staff.Commands;
using SHL.Application.DTO.Company.Request;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces;
using SHL.Application.IServices;
using SHL.Domain.Models;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IStaffService _service;
        private readonly IStaffRepository staffRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IMediator mediator;

        public UserController(IStaffService service,
            IStaffRepository staffRepository,
            IUserIdentityService userIdentityService,
            IMediator mediator) 

        {
            this._service = service;
            this.staffRepository = staffRepository;
            this.userIdentityService = userIdentityService;
            this.mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] StaffLoginDto dto)
        {
            var staffLoginResponse = await _service.StaffLogin(dto.Email, dto.Password);
            return Ok(staffLoginResponse);
        }

        [HttpGet("profile")]
        [Authorize(Policy =SHLAuthorizationPolicy.Employee)]
        public async Task<ActionResult> ProfileAsync()
        {
            var profile = await staffRepository.ProfileAsync(userIdentityService.SubjectId);

            return Ok(profile);
        }


        [HttpPost("Onboarding")]
        public async Task<ActionResult> OnboardingAsync([FromBody]StaffOnboardingDto model)
        {
            await mediator.Send(new StaffOnboardingCommand(model));
            return Ok();
        }

        [HttpPost("EditProfile")]
        [Authorize(Policy = SHLAuthorizationPolicy.Employee)]
        public async Task<ActionResult> EditProfileAsync([FromBody] EditProfileDto model)
        {
            await mediator.Send(new EditProfileCommand(model));
            return Ok();
        }
    }
}
