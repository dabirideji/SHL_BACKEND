using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Identity;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Domain.Models;

namespace SHL.Infrastructure.Services
{
    public class UserVerificationService : IUserVerificationService
    {
        private readonly IUserVerificationRepository userVerificationRepository;
        private readonly IUserIdentityService userIdentityService;

        public UserVerificationService(IUserVerificationRepository userVerificationRepository, IUserIdentityService userIdentityService)
        {
            this.userVerificationRepository = userVerificationRepository;
            this.userIdentityService = userIdentityService;
        }
        public async Task<UserVerification> AddUserverificationAsync(UserVerification newUserVerification)
        {
            var result=await userVerificationRepository.AddAsync(newUserVerification);
            return result;
        }

        public async Task<UserVerification> GetUserVerificationAsync()
        {
            var userId = userIdentityService.SubjectId.ToString();
            var result = userVerificationRepository.Get().FirstOrDefault(x => x.ApplicationUserId == userId);
            return result;
        }

        public async Task<UserVerification> UpdateUserVerificationAsync(UpdateUserDTO verifyUser)
        {
            var userId = userIdentityService.SubjectId.ToString();

            var userVerify = userVerificationRepository
                                .Get()
                                .FirstOrDefault(x => x.ApplicationUserId == userId);

            if (userVerify == null)
            {
                ApiException.ClientError("User profile not found", 404);
            }
            userVerify.FirstName = verifyUser.FirstName;
            userVerify.LastName = verifyUser.LastName;
            userVerify.OtherName = verifyUser.OtherName;
            userVerify.BVN = verifyUser.BVN;
            userVerify.Phone_no = verifyUser.Phone_no;
            userVerify.IsSent = true;
            userVerify.IsFreeMode = true;
            userVerify.IsPolicyAccepted = true;
            userVerify.DateModified = DateTime.UtcNow;

            return await userVerificationRepository.UpdateAsync(userVerify);
        }
        public async Task<UserVerification> UpdateUserAddressAsync(UpdateAddressDTO addressDTO)
        {
            var userId = userIdentityService.SubjectId.ToString();
            var userVerify = userVerificationRepository
                                .Get()
                                .FirstOrDefault(x => x.ApplicationUserId == userId);
            if (userVerify == null)
            {
                ApiException.ClientError("User profile not found", 404);
            }
            userVerify.StreetAddress = addressDTO.Street;
            userVerify.CountryId = addressDTO.CountryId;
            userVerify.StateId = addressDTO.StateId;
            userVerify.lgaId = addressDTO.LgaId;
            userVerify.ZipCode = addressDTO.ZipCode;
            userVerify.DateModified = DateTime.UtcNow;

            return await userVerificationRepository.UpdateAsync(userVerify);
        }
        public async Task<UserVerification> UpdateUserBVNAndNINAsync(UpdateBVNAndNINDTO updateBVNAndNINDTO)
        {
            var userId = userIdentityService.SubjectId.ToString();

            var userVerify = userVerificationRepository
                                .Get()
                                .FirstOrDefault(x => x.ApplicationUserId == userId);

            if (userVerify == null)
            {
                ApiException.ClientError("User profile not found", 404);
            }
            userVerify.NIN = updateBVNAndNINDTO.NIN;
            userVerify.BVN = updateBVNAndNINDTO.BVN;
            userVerify.DateModified = DateTime.UtcNow;

            return await userVerificationRepository.UpdateAsync(userVerify);
        }
     
    }
}
