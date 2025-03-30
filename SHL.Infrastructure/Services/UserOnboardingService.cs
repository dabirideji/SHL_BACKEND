using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using CSL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SHL.Application.DTO.Identity;
using SHL.Application.IServices;
using SHL.Application.Response;
using SHL.Application.TokenProviders;

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

        public async ValueTask<DefaultResponse<UserResponseDTO>> CreateUserAsync(CreateUserDTO userModel)
        {
            try
            {
            if (userModel == null)
            {
                return new DefaultResponse<UserResponseDTO>
                {
                     ResponseCode ="404",
                     ResponseMessage="Invalid Model",
                     Status=false,
                };
            }
            string email=string.Empty; string phonenumber=string.Empty;
            var fetchEmailOrPhone= EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            if (fetchEmailOrPhone == "Email") {email = userModel.EmailOrPhoneNumber;} else {phonenumber=userModel.EmailOrPhoneNumber.ToString();}
            var user = new ApplicationUser
            {
                UserName=userModel.EmailOrPhoneNumber,
                Email=email,
                PhoneNumber = "234" + phonenumber.Substring(1, 10),
                CompanyId=userModel.CompanyId,
                IsAdmin=userModel.IsAdmin,
            };
            var result = await userManager.CreateAsync(user, userModel.EmailOrPhoneNumber);
            if (result.Succeeded)
            {
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
                //send OTP
                await emailService.SendMail(user.Email,otp,"SHL OTP");

                var userData = await UserResponses(user);
                return new DefaultResponse<UserResponseDTO>
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Created",
                    Status = true,
                    Data = userData
                };

            }
              return new DefaultResponse<UserResponseDTO> { Status = false, ResponseMessage = "Failed to create user", Errors = result.Errors.Select(e => e.Description).ToList() };
            }
            catch (Exception ex)
            {
                return new DefaultResponse<UserResponseDTO>{ResponseCode = "500",ResponseMessage = ex.Message,Status = false };
            }

        }
        public async ValueTask<DefaultResponse<UserResponseDTO>> UserLoginAsync(LoginDTO userModel)
        {
            try
            {

            var user = await userManager.FindByEmailAsync(userModel.Email);
            if (user == null) { return new DefaultResponse<UserResponseDTO> { ResponseCode = "404", Status = false, ResponseMessage = "User not found" }; }
            var result = await signInManager.CheckPasswordSignInAsync(user, userModel.Password, false);
            if (result.Succeeded) {
                var userData = await UserResponses(user);
                return new DefaultResponse<UserResponseDTO>
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Login",
                    Status = true,
                    Data = userData
                };
            }
            return new DefaultResponse<UserResponseDTO> {ResponseCode="400",Status=false,ResponseMessage="Invalid username or password" };

            }
            catch (Exception ex)
            {
                return new DefaultResponse<UserResponseDTO> { ResponseCode = "500", Status = false, ResponseMessage = ex.Message};
            }
        }
        public async ValueTask<DefaultResponse<UserResponseDTO>> ForgotPasswordAsync(string email)
        {
            try
            {

            var user = await userManager.FindByEmailAsync(email);
            if (user == null) { return new DefaultResponse<UserResponseDTO> { ResponseCode = "404", Status = false, ResponseMessage = "User not found" }; }
            var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
            await emailService.SendMail(user.Email, otp, "SHL OTP");

            var userData = await UserResponses(user);
            return new DefaultResponse<UserResponseDTO>
            {
                ResponseCode = "200",
                ResponseMessage = "otp has been sent to you",
                Status = true,
                Data = userData
            };

            }
            catch (Exception ex)
            {
                logger.LogInformation($"Error for Forgot Password: {ex.Message}");
                return new DefaultResponse<UserResponseDTO>
                {
                    ResponseCode = "500",
                    ResponseMessage = ex.Message,
                    Status = false,
                };
            }
        }
        public async ValueTask<DefaultResponse<UserResponseDTO>> ResetPasswordAsync(ResetPasswordDTO userModel)
        {
            try
            {

                var user = await userManager.FindByIdAsync(userIdentityService.SubjectId);
                if (user == null)
                {
                    return DefaultResponse<UserResponseDTO>.ErrorMessage("Unable to retrieve user data. Try again later.");
                }
                var result = await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), userModel.ConfirmPassword);
                if (result.Succeeded)
                {
                    return DefaultResponse<UserResponseDTO>.SuccessMessage("Password has been reset successfully.");
                }
                else
                {
                    return DefaultResponse<UserResponseDTO>.ErrorMessage("Password reset failed");
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Error for Reset Password: {ex.Message}");
                return new DefaultResponse<UserResponseDTO>
                {
                  ResponseCode="500",
                  ResponseMessage = ex.Message,
                  Status = false,
                };
            }
        }
        public async ValueTask<ApplicationUser> GetUserByIdAsync(string UserId)
        {
            return await userManager.FindByIdAsync(UserId);
        }

        public async ValueTask<DefaultResponse<UserResponseDTO>> UpdateUserAsync(UpdateUserDTO userModel)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<DefaultResponse<bool>> VerifyOtp(string otp)
        {
            var user = await userManager.FindByIdAsync(userIdentityService.SubjectId);
            var result = await userManager.VerifyTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider, otp);
            if (result)
            {
                return new DefaultResponse<bool> {Status=true,ResponseCode="200" };
            }
            else
            {
                return DefaultResponse<bool>.ErrorMessage("Incorrect OTP. Please try again!");
            }
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
        private async ValueTask<UserResponseDTO> UserResponses(ApplicationUser user)
        {
            var registeredModel = new UserResponseDTO
            {
                PhoneNumber = user.PhoneNumber,
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Token = await tokenServices.CreateTokenAsync(user),
  
            };

            return registeredModel;
        }
        

       
    }
}
