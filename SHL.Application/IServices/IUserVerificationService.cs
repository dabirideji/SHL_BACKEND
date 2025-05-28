using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.DTO.Identity;
using SHL.Domain.Models;

namespace SHL.Application.IServices
{
    public interface IUserVerificationService
    {
        Task<UserVerification> GetUserVerificationAsync();
        Task<UserVerification> UpdateUserVerificationAsync(UpdateUserDTO verifyUser);
        Task<UserVerification> AddUserverificationAsync(UserVerification newUserVerification);
    }
}
