using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class PayoutAccountService : GenericService<PayoutAccount, CreatePayoutAccountDto, UpdatePayoutAccountDto, ReadPayoutAccountDto>, IPayoutAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayoutAccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
        }
    }















}
