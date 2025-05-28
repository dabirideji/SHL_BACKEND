using System.Text.RegularExpressions;
using CSL.Application.Utils.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Identity;
using SHL.Application.DTO.SendEmail;
using SHL.Application.IServices;
using SHL.Application.TokenProviders;
using SHL.Domain.Models;
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
        private readonly ISmsService smsService;
        private readonly IShareholderService shareholderService;
        private readonly IUserVerificationService userVerificationService;

        public UserOnboardingService(UserManager<ApplicationUser> userManager, 
            IConfiguration configuration,IEmailService emailService,IUserIdentityService userIdentityService,
            SignInManager<ApplicationUser> signInManager, ILogger<UserOnboardingService> logger,
            ITokenServices tokenServices, ISmsService smsService,IShareholderService shareholderService,
            IUserVerificationService userVerificationService)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.emailService = emailService;
            this.userIdentityService = userIdentityService;
            this.signInManager = signInManager;
            this.logger = logger;
            this.tokenServices = tokenServices;
            this.smsService = smsService;
            this.shareholderService = shareholderService;
            this.userVerificationService = userVerificationService;
        }

        public async Task<UserResponseDTO> CreateUserAsIndividualAsync(CreateUserAsIndividualDTO userModel)
        {
            var user = new ApplicationUser();
            string email=string.Empty; string phonenumber=string.Empty;
            var fetchEmailOrPhone= EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            var checkUser = await CheckExistingUser(userModel.EmailOrPhoneNumber);
            if (checkUser==true)
            {
                ApiException.ClientError("You have an account already on ShareholderLive Portal! Sign In to access your account.", 400);
            }
            if (fetchEmailOrPhone == "Email")
            {
                user =new ApplicationUser()
                {
                    FullName=userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    Email = userModel.EmailOrPhoneNumber,
                    UserVerification = new UserVerification
                    {
                        Email = email,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true
                    }

                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    FullName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    PhoneNumber ="234"+ userModel.EmailOrPhoneNumber,
                    UserVerification = new UserVerification
                    {
                        Email = email,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true
                    }
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
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, "Custom");
                //send OTP
                if (fetchEmailOrPhone == "Email")
                {
                    await SendOtpEmailInternalAsync(user.Email, otp);
                }
                else
                {
                    
                    await smsService.SendSmsAsync(user.PhoneNumber, otp);
                }
                var userData = await UserResponses(user);
                return userData;
            }
        }
        
        public async Task<UserResponseDTO> CreateUserAsInstitutionalAsync(CreateUserAsInstitutionDTO userModel)
        {
            var user = new ApplicationUser();
            var verifyUser = new VerifyInviteDTO();
            string email = string.Empty; string phonenumber = string.Empty;
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            var checkUser = await CheckExistingUser(userModel.EmailOrPhoneNumber);
            if (checkUser == true)
            {
                ApiException.ClientError("You have an account already on ShareholderLive Portal! Sign In to access your account.", 400);
            }
            if (fetchEmailOrPhone == "Email")
            {
                verifyUser = shareholderService.GetShareholder(userModel.EmailOrPhoneNumber, userModel.CompanyId);
                if (verifyUser == null || verifyUser.CompanyId == 0)
                {
                    ApiException.ClientError("You have an account already on ShareholderLive Portal! Sign In to access your account.", 400);

                }
                user = new ApplicationUser()
                {
                    FullName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    Email = userModel.EmailOrPhoneNumber,
                    UserVerification = new UserVerification
                    {
                        DefaultCompanyId = verifyUser.CompanyId,
                        DefaultAcctNo = verifyUser.acctno,
                        FirstName = verifyUser.FirstName,
                        LastName = verifyUser.LastName,
                        OtherName = verifyUser.OtherName,
                        BVN = verifyUser.BVN,
                        Holder_type = verifyUser.Holder_type,
                        Email = verifyUser.EmailTo,
                        Phone_no = verifyUser.Phone_no,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true,
                       // InfoUpdateStatus="",
                        
                    }

                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    FullName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    PhoneNumber = "234" + userModel.EmailOrPhoneNumber,
                    UserVerification = new UserVerification
                    {
                        DefaultCompanyId = verifyUser.CompanyId,
                        DefaultAcctNo = verifyUser.acctno,
                        FirstName = verifyUser.FirstName,
                        LastName = verifyUser.LastName,
                        OtherName = verifyUser.OtherName,
                        BVN = verifyUser.BVN,
                        Holder_type = verifyUser.Holder_type,
                        Email = verifyUser.EmailTo,
                        Phone_no = verifyUser.Phone_no,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true
                    }
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
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, "Custom");
                //send OTP
                if (fetchEmailOrPhone == "Email")
                {
                    await SendOtpEmailInternalAsync(user.Email, otp);
                }
                else
                {
                   await smsService.SendSmsAsync(user.PhoneNumber, otp);
                }
                
                var userData = await UserResponses(user);
                return userData;
            }
        }
        public async Task<UserResponseDTO> CreateUserAsVendorAsync(CreateUserAsVendorDTO userModel)
        {
            var user = new ApplicationUser();
            var verifyUser = new VerifyInviteDTO();
            string email = string.Empty; string phonenumber = string.Empty;
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.EmailOrPhoneNumber);
            var checkUser = await CheckExistingUser(userModel.EmailOrPhoneNumber);
            if (checkUser == true)
            {
                ApiException.ClientError("You have an account already on ShareholderLive Portal! Sign In to access your account.", 400);
            }
            if (fetchEmailOrPhone == "Email")
            {
                verifyUser = shareholderService.GetShareholder(userModel.EmailOrPhoneNumber, userModel.CompanyId);
                if (verifyUser == null || verifyUser.CompanyId == 0)
                {
                    ApiException.ClientError("You have an account already on ShareholderLive Portal! Sign In to access your account.", 400);

                }
                user = new ApplicationUser()
                {
                    FullName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    Email = userModel.EmailOrPhoneNumber,
                    SubsidiaryId=userModel.BusinessCategoryId,
                    UserVerification = new UserVerification
                    {
                        DefaultCompanyId = verifyUser.CompanyId,
                        DefaultAcctNo = verifyUser.acctno,
                        FirstName = verifyUser.FirstName,
                        LastName = verifyUser.LastName,
                        OtherName = verifyUser.OtherName,
                        BVN = verifyUser.BVN,
                        Holder_type = verifyUser.Holder_type,
                        Email = verifyUser.EmailTo,
                        Phone_no = verifyUser.Phone_no,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true
                    }
                };
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = new ApplicationUser
                {
                    FullName = userModel.FullName,
                    UserName = userModel.EmailOrPhoneNumber,
                    CompanyId = userModel.CompanyId,
                    PhoneNumber = "234" + userModel.EmailOrPhoneNumber,
                    SubsidiaryId = userModel.BusinessCategoryId,
                    UserVerification = new UserVerification
                    {
                        DefaultCompanyId = verifyUser.CompanyId,
                        DefaultAcctNo = verifyUser.acctno,
                        FirstName = verifyUser.FirstName,
                        LastName = verifyUser.LastName,
                        OtherName = verifyUser.OtherName,
                        BVN = verifyUser.BVN,
                        Holder_type = verifyUser.Holder_type,
                        Email = verifyUser.EmailTo,
                        Phone_no = verifyUser.Phone_no,
                        IsSent = true,
                        IsFreeMode = true,
                        IsPolicyAccepted = true
                    }
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
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, "Custom");
                //send OTP
                if (fetchEmailOrPhone == "Email")
                {
                    await SendOtpEmailInternalAsync(user.Email, otp);
                }
                else
                {

                    await smsService.SendSmsAsync(user.PhoneNumber, otp);
                }
                var userData = await UserResponses(user);
                return userData;
            }
        }

        public async Task<UserResponseDTO> UserLoginAsync(LoginDTO userModel)
        {
            var user = new ApplicationUser();
            var fetchEmailOrPhone = EstractEmailOrPhoneNumber(userModel.Email);
            if (fetchEmailOrPhone == "Email")
            {
                user = await userManager.FindByEmailAsync(userModel.Email);
            }
            else if (fetchEmailOrPhone == "PhoneNumber")
            {
                user = userManager.Users.FirstOrDefault(x => x.PhoneNumber == userModel.Email);
            }
            if (user == null) {
                ApiException.ClientError("USER NOT FOUND", 404, new { user });
            }
           
            if (user.EmailConfirmed == false|| user.PhoneNumberConfirmed==false)
            {
                //send OTP
                var otp = await userManager.GenerateTwoFactorTokenAsync(user, "Custom");
                if (fetchEmailOrPhone == "Email")
                {
                    await SendOtpEmailInternalAsync(user.Email, otp);
                }
                else
                {

                    await smsService.SendSmsAsync(user.PhoneNumber, otp);
                }
                //return token to verify account
                var jwt_token = await tokenServices.CreateTokenAsync(user);
                var tokenResponse = new UserResponseDTO()
                {
                    jwt_token = jwt_token,
                };
                return tokenResponse;
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, userModel.Password, false);
            if (!result.Succeeded)
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
            //send opt
            var otp = await userManager.GenerateTwoFactorTokenAsync(user, AppTokenProvider.TotpProvider);
            await SendOtpEmailInternalAsync(user.Email, otp);


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

        public async Task<bool> VerifyOtp(VerifyOtpDto model)
        {
            var user = await userManager.FindByIdAsync(userIdentityService.SubjectId.ToString());
            var result = await userManager.VerifyTwoFactorTokenAsync(user, "Custom", model.otp);
            if (result==false)
            {
                ApiException.ClientError("UNABLE TO VERIFY OTP", 400);
                return false;
            }
            user.EmailConfirmed = true;
            await userManager.UpdateAsync(user);
            return true;
        }
        private async Task SendOtpEmailInternalAsync(string recipientEmail, string otp, List<string>? bccEmails = null, List<EmailAttachment>? attachments = null)
        {
            var emailSender = new EmailModelDto
            {
                Mail = recipientEmail,
                BCCEmails = bccEmails,
                Subject = "One Time Password",
                MessageBody = $"Your one time code is {otp}",
                Attachments = attachments
            };

            var result = await emailService.SendMail(emailSender);

            if (!result.Success)
            {
                logger.LogWarning("Failed to send OTP email to {Email}: {Error}", recipientEmail, result.ErrorMessage);

            }
        }
        private async Task<bool> CheckExistingUser(string EmailOrPhoneNumber)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool result = false;
            if (Regex.IsMatch(EmailOrPhoneNumber, emailPattern))
            {
                var checkUserExist = await userManager.FindByEmailAsync(EmailOrPhoneNumber);
                if (checkUserExist != null) 
                {  result=true; }
            }
            else
            {
                var checkUserExist = userManager.Users.Where(x=>x.PhoneNumber==EmailOrPhoneNumber);
                if (checkUserExist.Any())
                {
                    result= true;
                }
            }
            return result;
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
                last_name = user?.FullName,
                email = user.Email,
                isAdmin = user.IsAdmin,
                company_id = user.CompanyId,
                jwt_token = await tokenServices.CreateTokenAsync(user),
  
            };

            return registeredModel;
        }  
    }
}
