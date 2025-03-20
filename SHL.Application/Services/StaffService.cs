using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using SHL.Domain.Models;
using SHL.Domain.Models.Categories;
using System.Security.Claims;

namespace InventoryManagement.Application.Services.Customer
{
    public class StaffService : GenericService<Staff, CreateStaffDto, UpdateStaffDto, ReadStaffDto>, IStaffService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;
        private readonly UserManager<CompanyUser> userManager;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly ICompanyRepository companyRepository;

        public StaffService(IUnitOfWork unitOfWork, IMapper mapper, IContactService contactService,
            UserManager<CompanyUser> userManager,
            ICompanyUserRepository companyUserRepository,
            ICompanyRepository companyRepository) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            this._contactService = contactService;
            this.userManager = userManager;
            this.companyUserRepository = companyUserRepository;
            this.companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<Staff> AddAsync(CreateStaffDto dto)
        {
            // create contact as well
            CreateContactDto contactDto = new CreateContactDto
            {
                ContactType = ContactType.EMPLOYEE,
                ContactName = dto.FirstName + " " + dto.LastName,
                ContactEmail = dto.Email,
                ContactPhoneNumber = dto.PhoneNumber
            };
            if (string.IsNullOrWhiteSpace(contactDto.ContactName))
            {
                contactDto.ContactName = dto.Username;
            }
            await _contactService.AddAsync(contactDto);
            return await base.AddAsync(dto);
        }

        public async Task<ReadStaffDto> StaffLogin(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
            {
                ApiException.ClientError("Invalid Credentials");
                return default;
            }

            if (!string.Equals( user.StaffStatus, StaffStatus.ACTIVE.ToString(),StringComparison.OrdinalIgnoreCase))
            {
                ApiException.ClientError("user is not active, kindly contact your administrator");                
            }
                var isValid = await userManager.CheckPasswordAsync(user!, password);
            if (!isValid) ApiException.ClientError("Invalid Credentials");

            var claims = await userManager.GetClaimsAsync(user!);
            var roles = await userManager.GetRolesAsync(user!);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var accessToken = companyUserRepository.GenerateToken(user!, claims);
            var companyId = claims!.First(c => c.Type == "companyid");
            var companyInfo = await companyRepository.GetByIdAsync(Guid.Parse(companyId.Value));

            return new ReadStaffDto()
            {
                AccessToken = accessToken,
                EmailAddress = email,
                FirstName = user!.FirstName ?? "",
                LastName = user.LastName ?? "",
                CompanyLogo = companyInfo!.LogoUrl,
                CompanyName = companyInfo.CompanyName,
                SharePrice = companyInfo.CompanySharePriceValuation
            };
            // var _staffRepository = _unitOfWork.GetRepository<Staff>();

            //var validStaff =await _staffRepository.GetAsync(x=>x.Email.ToLower()==email.ToLower());
            //if(validStaff == null)
            //{
            // ApiException.ClientError("LOGIN FAILED  || INVALID EMAIL ADDRESS");
            //}

            //var validPassword=validStaff.Password==password;
            //if(!validPassword)
            //{
            // ApiException.ClientError("LOGIN FAILED  || INVALID PASSWORD");
            //}

            //var mappedStaff= _mapper.Map<ReadStaffDto>(validStaff);
            //return mappedStaff;
        }
    }















}
