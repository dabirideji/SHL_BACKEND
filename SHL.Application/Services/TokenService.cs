using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Services;
using SHL.Domain.Models;
using SHL.Domain.Models.Categories;

namespace InventoryManagement.Application.Services.Customer
{
    public class TokenService : GenericService<Token, CreateTokenDto, UpdateTokenDto, ReadTokenDto>, ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        public TokenService(IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService) : base(unitOfWork, mapper)
        {
            this._mailService = mailService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SendToken(SendTokenDto dto, int duration = 10, TokenType tokenType = TokenType.EMAIL_VERIFICATION)
        {
            //var _tokenRepository = _unitOfWork.GetRepository<Token>();
            //// clear previously sent token.
            //var previouslySentTokens = (await _tokenRepository.GetAllAsync(x => x.UserReferenceValue == dto.EmailAddress)).ToList();
            //if (previouslySentTokens != null && previouslySentTokens.Count() > 0)
            //{
            //    await _tokenRepository.DeleteRangeAsync(previouslySentTokens);
            //}

            //Token token = new Token();
            //token.TokenType = tokenType;
            //token.UserReferenceValue = dto.EmailAddress;
            //token.TokenTitle = dto.Title;
            //token.TokenExpiryDurationInMins = duration;
            //token.TokenExpiryTime = DateTime.Now.AddMinutes(token.TokenExpiryDurationInMins);
            //token.TokenCode = GenerateToken(6);
            //var existingToken = await _tokenRepository.GetAsync(x => x.UserReferenceValue.ToLower() == dto.EmailAddress.ToLower());
            //if (existingToken != null)
            //{
            //    await _tokenRepository.DeleteAsync(existingToken.Id);
            //}
            //await _tokenRepository.AddAsync(token);
            //await _unitOfWork.SaveChangesAsync();
            //var mailMessageBody = $"REGISTRATION TOKEN : {token.TokenCode}";
            //var mailSubject = token.TokenType.ToString().ToUpper();
            //await _mailService.SendMail(dto.EmailAddress, mailMessageBody, mailSubject);
            return true;
        }


        public async Task<bool> VerifyToken(string token, string userReferenceValue)
        {
            //var _tokenRepository = _unitOfWork.GetRepository<Token>();
            //var tokenCheck = await _tokenRepository.GetAsync(x => x.UserReferenceValue == userReferenceValue);



            //if (tokenCheck == null)
            //{
            //    ApiException.ClientError("Invalid USER");
            //    return false;
            //}

            //if (tokenCheck.TokenCode != token)
            //{
            //    ApiException.ClientError("Invalid token");
            //    return false;
            //}

            //if (DateTime.Now > tokenCheck.TokenExpiryTime)
            //{
            //    _tokenRepository.DeleteAsync(tokenCheck.Id);
            //    await _unitOfWork.SaveChangesAsync();
            //    ApiException.ClientError("Token has expired");
            //}

            //// user.UserIsVerified = true;
            //_tokenRepository.DeleteAsync(tokenCheck.Id);
            //await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private string GenerateToken(int amt = 4)
        {
            Random random = new Random();
            int code = random.Next(1000, 10000);
            return code.ToString($"D{amt}");
        }
    }















}
