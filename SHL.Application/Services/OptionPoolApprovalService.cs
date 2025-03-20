using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class OptionPoolApprovalService : GenericService<OptionPoolApproval, CreateOptionPoolApprovalDto, UpdateOptionPoolApprovalDto, ReadOptionPoolApprovalDto>, IOptionPoolApprovalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OptionPoolApprovalService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
        }
    }















}
