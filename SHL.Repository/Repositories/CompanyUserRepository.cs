using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SHL.Application.AppSettings;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Account;
using SHL.Application.DTO.Company;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces;
using SHL.Application.Models;
using SHL.Application.Services;
using SHL.Domain.Models.Categories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SHL.Repository.Repositories
{
    public class CompanyUserRepository : GenericRepository<CompanyUser>, ICompanyUserRepository
    {

        private readonly JwtOptions jwtOptions;
        private readonly UserManager<CompanyUser> userManager;
        private readonly ICompanyRepository companyRepository;
        private readonly IStaffRepository staffRepository;
        private readonly SHLMasterDbContext SHLMasterDbContext;
        private readonly IDbConnectionAccessor dbConnectionAccessor;
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMailService mailService;

        public CompanyUserRepository(SHLTennantDbContext context,
            UserManager<CompanyUser> userManager,
            ICompanyRepository companyRepository,
            IStaffRepository staffRepository,
            ICacheManager cacheManager,
            IOptionsSnapshot<JwtOptions> jwtOptions,
            SHLMasterDbContext SHLMasterDbContext,
            IDbConnectionAccessor dbConnectionAccessor,
            IDbContextFactory dbContextFactory,
            IMailService mailService) : base(context, cacheManager)
        {
            this.jwtOptions = jwtOptions.Value;
            this.userManager = userManager;
            this.companyRepository = companyRepository;
            this.staffRepository = staffRepository;
            this.SHLMasterDbContext = SHLMasterDbContext;
            this.dbConnectionAccessor = dbConnectionAccessor;
            this.dbContextFactory = dbContextFactory;
            this.mailService = mailService;
        }
        public string GenerateToken(CompanyUser user, IEnumerable<Claim> claims)
        {

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwtOptions.IssuerName,
                jwtOptions.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(24),
                signingCredentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }

        public async Task<IdentityResult> OnboardAsync(OnboardDto dto)
        {
            var domain = dto.CompanyEmail.Split('@')[1];
            var connectionString = await dbContextFactory.DeployDatabaseInstance(domain);
            var companyInfo = new CompanyInfo
            {
                DomainName = dto.DomainName,
                Address = dto.Address,
                CompanyName = dto.CompanyName,
                NormalizedDomainName = domain.ToUpperInvariant(),
                IsActive = true,
                ConnectionString = connectionString
            };
            await SHLMasterDbContext.CompanyInfo.AddAsync(companyInfo);
            await SHLMasterDbContext.SaveChangesAsync();

            // var companyInfo = await GetCompanyIdAsync(dto.CompanyEmail);

            var companyUser = new CompanyUser
            {
                Email = dto.CompanyEmail,
                UserName = dto.CompanyEmail,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                IsAdmin = true,
                Staff = new Staff
                {
                    CompanyId = companyInfo.Id,
                    StaffCode = "",
                    StaffDepartment = "",
                    StaffGrade = "",
                    StaffStatus = Domain.Models.Categories.StaffStatus.ACTIVE
                }
            };

            var company = new Company
            {
                Id = companyInfo.Id,
                CompanyName = companyInfo.CompanyName,
                CompanyAddress = companyInfo.Address,
                CompanyCurrencyCode = companyInfo.CompanyCurrencyCode,
                CompanyDomainName = companyInfo.DomainName
            };

            await companyRepository.AddAsync(company);

            var result = await userManager.CreateAsync(companyUser, dto.Password);

            if (result.Succeeded)
            {
                //add claims
                await AddUserClaimsAsync(companyUser, company.Id.ToString());

                //add roles
                var roles = Enum.GetNames<Domain.Enums.Role>();
                await AddUserToRolesAsync(companyUser, roles.ToList());
            }

            return result;
        }

        public async Task<IdentityResult> OnboardStaffAsync(StaffOnboardingDto staff, CancellationToken cancellationToken)
        {
            var companyInfo = await GetCompanyIdAsync(staff.EmailAddress);
            var companyUser = new CompanyUser
            {
                Email = staff.EmailAddress,
                UserName = staff.EmailAddress,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                PhoneNumber = staff.PhoneNumber,
                IsAdmin =false
            };

            var newStaff = new Staff
            {
                CompanyId = companyInfo.Id,
                //Bank = new StaffBank
                //{
                //    AccountNumber = staff.AccountNumber,
                //    SwitfCode = staff.SwitfCode,
                //    BankName = staff.BankName
                //},
                Designation = staff.Designation,
                StaffDepartment = staff.Department,
                StaffCode = staff.EmployeeId,
                StaffStatus = Domain.Models.Categories.StaffStatus.ACTIVE
            };
            companyUser.Staff = newStaff;
            // await staffRepository.AddAsync(newStaff);

            var result = string.IsNullOrEmpty(staff.Password) ? await userManager.CreateAsync(companyUser) :
                await userManager.CreateAsync(companyUser, staff.Password);

            if (result.Succeeded)
            {
                //add claims
                await AddUserClaimsAsync(companyUser, companyInfo.Id.ToString());

                //add roles
                await AddUserToRoleAsync(companyUser, Domain.Enums.Role.Employee.ToString());
            }

            return result;
        }

        public async Task<(IdentityResult, string)> GenerateEmailConfirmationTokenAsync(string userName, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return (result, "");
            }
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            return (IdentityResult.Success, code);
        }

        public async Task<IdentityResult> ConfirmEmailTokenAsync(string userName, string code, CancellationToken cancellationToken)
        {
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }

            var identityResult = await userManager.ConfirmEmailAsync(user, token);
            return identityResult;
        }

        public async Task<(IdentityResult, string)> GeneratePasswordResetTokenAsync(string userName, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return (result, "");
            }
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            return (IdentityResult.Success, code);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userName, string code, string newPassword, CancellationToken cancellationToken)
        {
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }

            var identityResult = await userManager.ResetPasswordAsync(user, token, newPassword);
            return identityResult;
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userName, string currentPassword, string newPassword, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }

            var changePasswordResult = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return changePasswordResult;
        }

        public async Task<(IdentityResult, string)> GenerateOtpAsync(string userName, string purpose)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return (result, "");
            }

            var otp = await userManager.GenerateUserTokenAsync(user, "TotpTokenProvider", purpose);

            return (IdentityResult.Success, otp);
        }

        public async Task<IdentityResult> ValidateOtpAsync(string userName, string purpose, string otp)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }

            var verificationResult = await userManager.VerifyUserTokenAsync(user, "TotpTokenProvider", purpose, otp);

            if (!verificationResult)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "Invalid", Description = "Invalid or expired otp" }]);
                return result;
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }
            user!.EmailConfirmed = true;
            var confirmationResult = await userManager.UpdateAsync(user!);
            return confirmationResult;
        }

        public async Task<(IdentityResult status, CompanyUser user)> CreateStaffWithoutPasswordAsync(StaffModel model)
        {
            var companyUser = new CompanyUser
            {
                Email = model.EmailAddress,
                UserName = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Staff = new Domain.Models.Staff
                {
                    CompanyId = model.CompanyId,
                    StaffCode = model.StaffCode,
                    StaffDepartment = model.StaffDepartment,
                    StaffGrade = model.StaffGrade,
                    StaffStatus = Domain.Models.Categories.StaffStatus.ACTIVE
                }
            };

            var result = await userManager.CreateAsync(companyUser);

            return (result, companyUser);
        }

        public async Task<IdentityResult> AddUserClaimsAsync(CompanyUser user, List<Claim> claims)
        {
            var result = await userManager.AddClaimsAsync(user, claims);
            return result;
        }

        public async Task SendStaffOnboardingLinkAsync(string frondEndBaseUrl, string emailAddress, string token, CancellationToken cancellationToken)
        {
            var profileUpdateLink = $"{frondEndBaseUrl}/employeesetup?email={emailAddress}&token={token}";
            await mailService!.SendMail(emailAddress, $"Welcome to EquityPlan, kindly click on this link to set-up your profile {profileUpdateLink}", "Welcome to EquityPlan");
        }
        public async Task<IdentityResult> UpdateEmployeeProfile(EmployeeInfoUpdateDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(dto.EmailAddress);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }

            user.PhoneNumber = dto.PhoneNumber;
            user.EmailConfirmed = true;

            var passwordResult = await userManager.AddPasswordAsync(user, dto.Password);
            if (passwordResult.Succeeded)
            {
                _ = await userManager.UpdateAsync(user);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.MobilePhone,user.PhoneNumber!),
                        new Claim(ClaimTypes.GivenName,user.FirstName!),
                        new Claim(ClaimTypes.Surname,user.LastName!)
                    };

                _ = await AddUserClaimsAsync(user, claims);
                await AddUserToRoleAsync(user, Domain.Enums.Role.Employee.ToString());
            }


            return passwordResult;
        }

        public async Task<IdentityResult> ChangeStaffStatusAsync(string userName, string status, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }
            var staffStatus = (StaffStatus)Enum.Parse(typeof(StaffStatus), status);
            user.StaffStatus = staffStatus.ToString();

            var changeStatusResult = await userManager.UpdateAsync(user);
            return changeStatusResult;
        }

        public async Task<IdentityResult> ToggleAdminAsync(string userName, bool isAdmin, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
            {
                var result = IdentityResult.Failed([new IdentityError() { Code = "NotFound", Description = "User not found" }]);
                return result;
            }
            user.IsAdmin = isAdmin;
            if (isAdmin)
            {
                return await userManager.AddToRoleAsync(user, Domain.Enums.Role.Employer.ToString());
            }
            else
            {
                return await userManager.RemoveFromRoleAsync(user, Domain.Enums.Role.Employer.ToString());
            }
        }

        async Task AddUserClaimsAsync(CompanyUser user, string companyId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber!),
                new Claim(ClaimTypes.GivenName,user.FirstName!),
                new Claim(ClaimTypes.Surname,user.LastName!),
                new Claim("companyid",companyId)
            };

            _ = await userManager.AddClaimsAsync(user, claims);
        }

        async Task AddUserToRoleAsync(CompanyUser user, string role)
        {
            _ = await userManager.AddToRoleAsync(user, role);
        }

        async Task AddUserToRolesAsync(CompanyUser user, List<string> roles)
        {
            _ = await userManager.AddToRolesAsync(user, roles);
        }

        async Task<CompanyInfo> GetCompanyIdAsync(string userEmail)
        {
            var domain = userEmail.Split('@')[1];
            var company = await SHLMasterDbContext.CompanyInfo
                .FirstOrDefaultAsync(c => c.DomainName.Contains(domain));

            if (company is null)
                ApiException.ClientError($"Company with domain {domain} not profiled");

            return company!;
        }
    }
}
