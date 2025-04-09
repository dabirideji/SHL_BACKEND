using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHL.Application.DTO.Identity;
using SHL.Application.IServices;

namespace SHL.IdentityServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserOnboardingService userOnboardingService;

        public UserController(IUserOnboardingService userOnboardingService)
        {
            this.userOnboardingService = userOnboardingService;
        }
        [HttpPost("SignUpAsGuest")]
        public async ValueTask<IActionResult> SignUpAsGuest([FromBody] CreateUserAsGuestDTO userDTO)
        {
            var result=await userOnboardingService.CreateUserAsGuestAsync(userDTO);
            return Ok(result);
        }
        [HttpPost("SignUpAsRetail")]
        public async ValueTask<IActionResult> SignUpAsRetail([FromBody] CreateUserAsRetailDTO userDTO)
        {
            var result = await userOnboardingService.CreateUserAsRetailAsync(userDTO);
            return Ok(result);
        }
        [HttpPost("SignUpAsInstitution")]
        public async ValueTask<IActionResult> SignUpAsInstitution([FromBody] CreateUserAsInstitutionDTO userDTO)
        {
            var result = await userOnboardingService.CreateUserAsInstitutionalAsync(userDTO);
            return Ok(result);
        }
        [HttpPost("SignUpAsVendor")]
        public async ValueTask<IActionResult> SignUpAsVendor([FromBody] CreateUserAsVendorDTO userDTO)
        {
            var result = await userOnboardingService.CreateUserAsVendorAsync(userDTO);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async ValueTask<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            var result = await userOnboardingService.UserLoginAsync(userDTO);
            return Ok(result);
        }
        [HttpPost("ForgotPassword/{email}")]
        public async ValueTask<IActionResult> ForgotPassword(string email)
        {
            var result = await userOnboardingService.ForgotPasswordAsync(email);
            return Ok(result); 
        }
        [HttpPost("ResetPassword")]
        public async ValueTask<IActionResult> ResetPassword([FromBody] ResetPasswordDTO userDTO)
        {
            var result = await userOnboardingService.ResetPasswordAsync(userDTO);
            return Ok(result);
        }
    }
}
