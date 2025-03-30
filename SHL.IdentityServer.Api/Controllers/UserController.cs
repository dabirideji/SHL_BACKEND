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
        [HttpPost("SignUp")]
        public async ValueTask<IActionResult> SignUp([FromBody] CreateUserDTO userDTO)
        {
            var result=await userOnboardingService.CreateUserAsync(userDTO);
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
