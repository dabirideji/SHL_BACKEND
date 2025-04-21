using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Identity;
using SHL.Application.IServices;
using SHL.Application.TokenProviders;
using SHL.Domain.Models.Identity;

namespace SHL.Infrastructure.Services
{
    public class UserOnboardingService: IUserOnboardingService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;
        private readonly IUserIdentityService userIdentityService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<UserOnboardingService> logger;
        private readonly ITokenServices tokenServices;

        public UserOnboardingService(UserManager<ApplicationUser> userManager, 
            IConfiguration configuration,IEmailService emailService,IUserIdentityService userIdentityService,
            SignInManager<ApplicationUser> signInManager, ILogger<UserOnboardingService> logger,ITokenServices tokenServices)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.emailService = emailService;
            this.userIdentityService = userIdentityService;
            this.signInManager = signInManager;
            this.logger = logger;
            this.tokenServices = tokenServices;
        }

        public async Task<UserResponseDTO> CreateUserAsIndividualAsync(CreateUserAsIndividualDTO userModel)
        {
            var user = new ApplicationUser();
            string email=string.Empty; string phonenumber=string.Empty;
            var fetchEmailOrPhone= EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            if (fetchEmailOrPhone == "Email")
            {
                user =new ApplicationUser()
                {
                    LastName=userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    Email = userModel.EmailOrPhoneNumber,
                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    PhoneNumber ="234"+ userModel.EmailOrPhoneNumber,
                };
            }
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded==false)
            {
            ApiException.ClientError("FAILED TO CREATE USER", 400, new {result});
            return null;
            }
            else
            {
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
                //send OTP
                await emailService.SendMail(user.Email, otp, "SHL OTP");

                var userData = await UserResponses(user);
                return userData;
            }
        }
        public async Task<UserResponseDTO> CreateUserAsRetailAsync(CreateUserAsRetailDTO userModel)
        {
            var user = new ApplicationUser();
            string email = string.Empty; string phonenumber = string.Empty;
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            if (fetchEmailOrPhone == "Email")
            {
                user = new ApplicationUser()
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    Email = userModel.EmailOrPhoneNumber,
                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    PhoneNumber = "234" + userModel.EmailOrPhoneNumber,

                };
            }
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded == false)
            {
                ApiException.ClientError("FAILED TO CREATE USER", 400, new { result });
                return null;
            }
            else
            {
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
                //send OTP
                await emailService.SendMail(user.Email, otp, "SHL OTP");

                var userData = await UserResponses(user);
                return userData;
            }
        }
        public async Task<UserResponseDTO> CreateUserAsInstitutionalAsync(CreateUserAsInstitutionDTO userModel)
        {
            var user = new ApplicationUser();
            string email = string.Empty; string phonenumber = string.Empty;
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            if (fetchEmailOrPhone == "Email")
            {
                user = new ApplicationUser()
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    Email = userModel.EmailOrPhoneNumber,
                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    PhoneNumber = "234" + userModel.EmailOrPhoneNumber,
                };
            }
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded == false)
            {
                ApiException.ClientError("FAILED TO CREATE USER", 400, new { result });
                return null;
            }
            else
            {
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
                //send OTP
                await emailService.SendMail(user.Email, otp, "SHL OTP");

                var userData = await UserResponses(user);
                return userData;
            }
        }
        public async Task<UserResponseDTO> CreateUserAsVendorAsync(CreateUserAsVendorDTO userModel)
        {
            var user = new ApplicationUser();
            string email = string.Empty; string phonenumber = string.Empty;
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            if (fetchEmailOrPhone == "Email")
            {
                user = new ApplicationUser()
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    Email = userModel.EmailOrPhoneNumber,
                    SubsidiaryId=userModel.BusinessCategoryId,
                    IsAdmin = userModel.IsAdmin,
                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    LastName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    PhoneNumber = "234" + userModel.EmailOrPhoneNumber,
                    SubsidiaryId = userModel.BusinessCategoryId,
                };
            }
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded == false)
            {
                ApiException.ClientError("FAILED TO CREATE USER", 400, new { result });
                return null;
            }
            else
            {
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
                //send OTP
                await emailService.SendMail(user.Email, otp, "SHL OTP");

                var userData = await UserResponses(user);
                return userData;
            }
        }

        public async Task<UserResponseDTO> UserLoginAsync(LoginDTO userModel)
        {

            var user = await userManager.FindByEmailAsync(userModel.Email);
            if (user == null) {
                ApiException.ClientError("USER NOT FOUND", 404, new { user });
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, userModel.Password, false);
            if (result.Succeeded == false)
            {
                ApiException.ClientError("LOGIN FAILED", 400, new { result });
                return null;
            }
            var userData = await UserResponses(user);
            return userData;
           
        }
        public async Task<UserResponseDTO> ForgotPasswordAsync(string email)
        {
           
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ApiException.ClientError("USER NOT FOUND", 404, new { user });
            }
            var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
            var sendotp= await emailService.SendMail(user.Email, otp, "SHL OTP");
            if (sendotp == false)
            {

                ApiException.ClientError("FAILED TO SEND OTP", 400);
                return null;
            }
            var userData = await UserResponses(user);
            return userData;


        }
        public async Task<UserResponseDTO> ResetPasswordAsync(ResetPasswordDTO userModel)
        {
            
                var user = await userManager.FindByIdAsync(userIdentityService.SubjectId.ToString());
                if (user == null)
                {
                    ApiException.ClientError("USER NOT FOUND", 404, new { user });
                }
                var result = await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), userModel.ConfirmPassword);
                if (result.Succeeded == false)
                {
                    ApiException.ClientError("FAILED TO RESET PASSWORD", 400, new { result });
                    return null;
                }

               return null;
        }
        public async Task<ApplicationUser> GetUserByIdAsync(string UserId)
        {
            return await userManager.FindByIdAsync(UserId);
        }

        public async Task<UserResponseDTO> UpdateUserAsync(UpdateUserDTO userModel)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> VerifyOtp(string otp)
        {
            var user = await userManager.FindByIdAsync(userIdentityService.SubjectId.ToString());
            var result = await userManager.VerifyTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider, otp);
            if (result==false)
            {
                ApiException.ClientError("UNABLE TO VERIFY OTP", 400);
                return false;
            }
            return true;
        }
        private string EstractEmailOrPhoneNumber(string EmailOrPhoneNumber)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (Regex.IsMatch(EmailOrPhoneNumber, emailPattern))
            {
                return "Email";
            }
            else
            {
                return "PhoneNumber";
            }
        }
        private async Task<UserResponseDTO> UserResponses(ApplicationUser user)
        {
            var registeredModel = new UserResponseDTO
            {
                phone_number = user.PhoneNumber,
                first_name = user?.FirstName,
                last_name = user?.LastName,
                email = user.Email,
                isAdmin = user.IsAdmin,
                company_id = user.CompanyId,
                jwt_token = await tokenServices.CreateTokenAsync(user),
  
            };

            return registeredModel;
        }

        
    }
}
