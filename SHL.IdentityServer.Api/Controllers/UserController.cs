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
        [HttpPost("SignUpAsIndividual")]
        public async ValueTask<IActionResult> SignUpAsIndividual([FromBody] CreateUserAsIndividualDTO userDTO)
        {
            var result=await userOnboardingService.CreateUserAsIndividualAsync(userDTO);
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
        [HttpPost("VerifyOtp")]
        public async ValueTask<IActionResult> VerifyOtp([FromBody] VerifyOtpDto userDTO)
        {
            var result = await userOnboardingService.VerifyOtp(userDTO);
            return Ok(result);
        }
       
    }
}
