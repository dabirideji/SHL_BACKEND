using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class OptionHolderSignatureService : GenericService<OptionHolderSignature, CreateOptionHolderSignatureDto, UpdateOptionHolderSignatureDto, ReadOptionHolderSignatureDto>, IOptionHolderSignatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OptionHolderSignatureService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<OptionHolderSignature> AddAsync(CreateOptionHolderSignatureDto dto)
        {
            return new OptionHolderSignature();
            //var _optionHolderRepo = _unitOfWork.GetRepository<OptionHolder>();
            //var _grantsRepo = _unitOfWork.GetRepository<Grant>();
            //var _optionPoolRepo = _unitOfWork.GetRepository<OptionPool>();
            //var _companyRepo = _unitOfWork.GetRepository<Company>();
            //var _staffRepo = _unitOfWork.GetRepository<Staff>();
            //var _portfolioRepo = _unitOfWork.GetRepository<Portfolio>();
            //var optionHoldingId = (Guid)dto.OptionHolderId;

            //if (optionHoldingId == null)
            //{
            //    ApiException.ClientError("INVALID OPTION HOLDING ID || OPTION HOLDING NOT FOUND", 400);
            //}

            //var optionHolding = await _optionHolderRepo.GetByIdAsync(optionHoldingId);
            //if (optionHolding == null)
            //{
            //    ApiException.ClientError("OPTION HOLDING NOT FOUND", 404);
            //}

            //if (optionHolding.OptionHolderStatus == SHL.Domain.Models.Categories.OptionHolderStatus.DISABLED)
            //{
            //    ApiException.ClientError("CANNOT PERFORM ACTION || OPTION HOLDINGS IS DISABLED");
            //}
            ////
            //// get portfolio
            //var grant = await _grantsRepo.GetByIdAsync(optionHolding.OptionHolderGrantId);
            //if(grant==null){
            //    ApiException.ClientError("ACTION FAILED || FAILED TO LOAD GRANT INFORMATION");
            //}
            //var optionPool = await _optionPoolRepo.GetByIdAsync((Guid)grant.GrantOptionPoolId);
            //if(optionPool==null){
            //    ApiException.ClientError("ACTION FAILED || FAILED TO LOAD POOL INFORMATION");
            //}
            //var company = await _companyRepo.GetByIdAsync((Guid)optionPool.OptionPoolCompanyId);
            //if(company==null){
            //    ApiException.ClientError("ACTION FAILED || FAILED TO LOAD COMPANY INFORMATION");
            //}

            //var optionHoldingPortfolio = await _portfolioRepo.GetAllAsync(x => x.OptionId == grant.Id);

            //var staff = (await _staffRepo.GetAsync(x => x.Email.ToLower() == optionHolding.OptionHolderEmailAddress.ToLower()));
            //if(staff==null){
            //    ApiException.ClientError("ACTION FAILED || FAILED TO LOAD STAFF INFORMATION");
            //}

            //optionHolding.OptionHolderStatus=SHL.Domain.Models.Categories.OptionHolderStatus.VESTING;
            //optionHolding.OptionHoldingIsSigned=true;
            //await _optionHolderRepo.UpdateAsync(optionHolding);
            //var existingPortfolio = optionHoldingPortfolio.FirstOrDefault(x => x.EmployeeEmail == staff.Email && x.OptionId == grant.Id);
            //if (existingPortfolio != null)
            //{
            //    return await base.AddAsync(dto);
            //}


            //Portfolio portfolio = new Portfolio();
            //portfolio.CompanyName = company.CompanyName;
            //portfolio.DilutedOwnershipPercentage = optionHolding.OptionHolderDilutedEquityPercentage;
            //portfolio.OptionId = grant.Id;
            //portfolio.OptionGrant = grant;
            //portfolio.EmployeeEmail = staff.Email;
            //portfolio.Employee = staff;
            //portfolio.TotalShareAmount = optionHolding.OptionHolderAmount;
            //portfolio.TotalShareUnits = optionHolding.OptionHolderAmount;
            //portfolio.TotalShareValuation = (2.46) * optionHolding.OptionHolderAmount;
            //portfolio.Status=SHL.Domain.Models.Categories.Status.ACTIVE;
            //await _portfolioRepo.AddAsync(portfolio);
            //return await base.AddAsync(dto);
        }
    }















}
