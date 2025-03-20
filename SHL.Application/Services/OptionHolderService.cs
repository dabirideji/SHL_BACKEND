using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class OptionHolderService : GenericService<OptionHolder, CreateOptionHolderDto, UpdateOptionHolderDto, ReadOptionHolderDto>, IOptionHolderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OptionHolderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<OptionHolder> AddAsync(CreateOptionHolderDto createDto)
        {
            await ValidateAndAdjustGrantAsync(createDto.OptionHolderGrantId, createDto.OptionHolderAmount);
            return await base.AddAsync(createDto);
        }

        public virtual async Task<IEnumerable<OptionHolder>> AddRangeAsync(IEnumerable<CreateOptionHolderDto> createDtos)
        {
            foreach (var createDto in createDtos)
            {
                await ValidateAndAdjustGrantAsync(createDto.OptionHolderGrantId, createDto.OptionHolderAmount);
            }

            return await base.AddRangeAsync(createDtos);
        }

        private async Task ValidateAndAdjustGrantAsync(Guid? grantId, double shareAmount)
        {
            //if (grantId == null)
            //{
            //    ApiException.ClientError("INVALID GRANT ID || FAILED TO CREATE OPTION HOLDER");
            //}

            //var _grantRepo = _unitOfWork.GetRepository<Grant>();
            //var grant = await _grantRepo.GetByIdAsync((Guid)grantId);

            //if (grant == null)
            //{
            //    ApiException.ClientError("INVALID GRANT ID || FAILED TO CREATE OPTION HOLDER");
            //}

            //grant.GrantShareAmountAvailable -= shareAmount;
            //await _grantRepo.UpdateAsync(grant);
            //await _unitOfWork.SaveChangesAsync();
        }
    }















}
