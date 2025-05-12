using SHL.Application.DTO.Identity;
using SHL.Domain.Models.Identity;

namespace SHL.Application.IServices
{
    public interface IUserOnboardingService
    {
        Task<UserResponseDTO> CreateUserAsIndividualAsync(CreateUserAsIndividualDTO userModel);
        Task<UserResponseDTO> CreateUserAsInstitutionalAsync(CreateUserAsInstitutionDTO userModel);
        Task<UserResponseDTO> CreateUserAsVendorAsync(CreateUserAsVendorDTO userModel);
        Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO userModel);
        Task<ApplicationUser> GetUserByIdAsync(string UserId);
        Task<UserResponseDTO> UserLoginAsync(LoginDTO userModel);
        Task<UserResponseDTO> ResetPasswordAsync(ResetPasswordDTO userModel);
        Task<UserResponseDTO> ForgotPasswordAsync(string email);
        Task<bool> VerifyOtp(VerifyOtpDto model);
    }
}
