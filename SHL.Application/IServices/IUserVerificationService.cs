using SHL.Application.DTO.Identity;
using SHL.Domain.Models;

namespace SHL.Application.IServices
{
    public interface IUserVerificationService
    {
        Task<UserVerification> GetUserVerificationAsync();
        Task<UserVerification> UpdateUserVerificationAsync(UpdateUserDTO verifyUser);
        Task<UserVerification> AddUserverificationAsync(UserVerification newUserVerification);
        Task<UserVerification> UpdateUserAddressAsync(UpdateAddressDTO addressDTO);
        Task<UserVerification> UpdateUserBVNAndNINAsync(UpdateBVNAndNINDTO updateBVNAndNINDTO);
    }
}
