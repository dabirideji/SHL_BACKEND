using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class GrantService : GenericService<Grant, CreateGrantDto, UpdateGrantDto, ReadGrantDto>, IGrantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrantService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Grant> AddAsync(CreateGrantDto createDto)
        {
            await ValidateAndAdjustOptionPoolAsync(createDto.GrantOptionPoolId, createDto.GrantShareAmountAvailable);
            return await base.AddAsync(createDto);
        }

        public virtual async Task<IEnumerable<Grant>> AddRangeAsync(IEnumerable<CreateGrantDto> createDtos)
        {
            foreach (var createDto in createDtos)
            {
                await ValidateAndAdjustOptionPoolAsync(createDto.GrantOptionPoolId, createDto.GrantShareAmountAvailable);
            }

            return await base.AddRangeAsync(createDtos);
        }

        /// <summary>
        /// Validates the Option Pool and adjusts available shares before adding a Grant.
        /// </summary>
        private async Task ValidateAndAdjustOptionPoolAsync(Guid? optionPoolId, double shareAmount)
        {
            //if (optionPoolId == null)
            //{
            //    ApiException.ClientError("INVALID POOL ID || FAILED TO CREATE GRANT");
            //}

            //var _optionPoolRepo = _unitOfWork.GetRepository<OptionPool>();
            //var optionPool = await _optionPoolRepo.GetByIdAsync((Guid)optionPoolId);

            //if (optionPool == null)
            //{
            //    ApiException.ClientError("INVALID POOL ID || FAILED TO CREATE GRANT");
            //}

            //optionPool.OptionPoolTotalShares -= shareAmount;
            //await _optionPoolRepo.UpdateAsync(optionPool);
            //await _unitOfWork.SaveChangesAsync();
        }

    }
}
