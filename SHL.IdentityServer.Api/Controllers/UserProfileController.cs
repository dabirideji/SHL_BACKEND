using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SHL.Application.DTO.Identity;
using SHL.Application.IServices;

namespace SHL.IdentityServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserVerificationService userVerificationService;

        public UserProfileController(IUserVerificationService userVerificationService)
        {
            this.userVerificationService = userVerificationService;
        }
        
        [HttpPut("UpdateAddress")]
        public async ValueTask<IActionResult> UpdateUser([FromBody] UpdateAddressDTO userDTO)
        {
            var result = await userVerificationService.UpdateUserAddressAsync(userDTO);
            return Ok(result);
        }
        [HttpPut("UpdateBVNAndNIN")]
        public async ValueTask<IActionResult> UpdateBVNAndNIN([FromBody] UpdateBVNAndNINDTO userDTO)
        {
            var result = await userVerificationService.UpdateUserBVNAndNINAsync(userDTO);
            return Ok(result);
        }
        [HttpGet("GetUserProfile")]
        public async ValueTask<IActionResult> GetUserProfile()
        {
            var result = await userVerificationService.GetUserVerificationAsync();
            return Ok(result);
        }
    }
}
