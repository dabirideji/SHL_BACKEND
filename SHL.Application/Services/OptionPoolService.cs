using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class OptionPoolService : GenericService<OptionPool, CreateOptionPoolDto, UpdateOptionPoolDto, ReadOptionPoolDto>, IOptionPoolService
    {
          private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OptionPoolService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<OptionPool> AddAsync(CreateOptionPoolDto createDto)
        {
            await ValidateAndAdjustCompanySharesAsync(createDto.OptionPoolCompanyId, createDto.OptionPoolTotalShares);
            return await base.AddAsync(createDto);
        }

        public virtual async Task<IEnumerable<OptionPool>> AddRangeAsync(IEnumerable<CreateOptionPoolDto> createDtos)
        {
            foreach (var createDto in createDtos)
            {
                await ValidateAndAdjustCompanySharesAsync(createDto.OptionPoolCompanyId, createDto.OptionPoolTotalShares);
            }

            return await base.AddRangeAsync(createDtos);
        }

        /// <summary>
        /// Validates the Option Pool and adjusts available shares before adding a OptionPool.
        /// </summary>
        private async Task ValidateAndAdjustCompanySharesAsync(Guid? companyId, double shareAmount)
        {
            //if (companyId == null)
            //{
            //    ApiException.ClientError("INVALID COMPANY ID || FAILED TO CREATE POOL");
            //}

            //var _companyRepo = _unitOfWork.GetRepository<Company>();
            //var company = await _companyRepo.GetByIdAsync((Guid)companyId);

            //if (company == null)
            //{
            //    ApiException.ClientError("INVALID COMPANY ID || FAILED TO CREATE POOL");
            //}

            //company.CompanyAvailableShareAmount -= shareAmount;
            //await _companyRepo.UpdateAsync(company);
            //await _unitOfWork.SaveChangesAsync();
        }
    }
    












}
