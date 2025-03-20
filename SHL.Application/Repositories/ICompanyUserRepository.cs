using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Account;
using SHL.Application.DTO.Company;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Models;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Repositories
{
    public interface ICompanyUserRepository : IGenericRepository<CompanyUser>
    {
        Task<IdentityResult> OnboardAsync(OnboardDto dto);
        string GenerateToken(CompanyUser user, IEnumerable<Claim> claims);
        Task<(IdentityResult, string)> GenerateEmailConfirmationTokenAsync(string userName, CancellationToken cancellationToken);
        Task<IdentityResult> ConfirmEmailTokenAsync(string userName, string code, CancellationToken cancellationToken);
        Task<(IdentityResult, string)> GeneratePasswordResetTokenAsync(string userName, CancellationToken cancellationToken);
        Task<IdentityResult> ResetPasswordAsync(string userName, string code, string newPassword, CancellationToken cancellationToken);
        Task<IdentityResult> ChangePasswordAsync(string userName, string currentPassword, string newPassword, CancellationToken cancellationToken);

        Task<(IdentityResult, string)> GenerateOtpAsync(string userName, string purpose);

        Task<IdentityResult> ValidateOtpAsync(string userName, string purpose, string otp);
        Task<IdentityResult> ConfirmEmailAsync(string userName);
        Task<(IdentityResult status, CompanyUser user)> CreateStaffWithoutPasswordAsync(StaffModel model);
        Task<IdentityResult> AddUserClaimsAsync(CompanyUser user, List<Claim> claims);
        Task<IdentityResult> UpdateEmployeeProfile(EmployeeInfoUpdateDto dto, CancellationToken cancellationToken);
        Task<IdentityResult> OnboardStaffAsync(StaffOnboardingDto staff, CancellationToken cancellationToken);
        Task SendStaffOnboardingLinkAsync(string frondEndBaseUrl, string emailAddress, string token, CancellationToken cancellationToken);
        Task<IdentityResult> ChangeStaffStatusAsync(string userName, string status, CancellationToken cancellationToken);
        Task<IdentityResult> ToggleAdminAsync(string userName, bool isAdmin, CancellationToken cancellationToken);
    }
}
