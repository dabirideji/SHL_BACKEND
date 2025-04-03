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
        Task<UserResponseDTO> CreateUserAsync(CreateUserDTO userModel);
        Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO userModel);
        Task<ApplicationUser> GetUserByIdAsync(string UserId);
        Task<UserResponseDTO> UserLoginAsync(LoginDTO userModel);
        Task<UserResponseDTO> ResetPasswordAsync(ResetPasswordDTO userModel);
        Task<UserResponseDTO> ForgotPasswordAsync(string email);
    }
}
