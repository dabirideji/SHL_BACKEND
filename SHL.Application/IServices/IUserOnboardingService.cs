using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Identity;
using SHL.Application.Interfaces;
using SHL.Application.Response;
using SHL.Domain.Models;

namespace SHL.Application.IServices
{
    public interface IUserOnboardingService
    {
        ValueTask<UserResponseDTO> CreateUserAsync(CreateUserDTO userModel);
        ValueTask<UserResponseDTO> UpdateUserAsync(UpdateUserDTO userModel);
        ValueTask<ApplicationUser> GetUserByIdAsync(string UserId);
        ValueTask<UserResponseDTO> UserLoginAsync(LoginDTO userModel);
        ValueTask<UserResponseDTO> ResetPasswordAsync(ResetPasswordDTO userModel);
        ValueTask<UserResponseDTO> ForgotPasswordAsync(string email);
    }
}
