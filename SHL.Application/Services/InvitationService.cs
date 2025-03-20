using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class InvitationService : GenericService<Invitation, CreateInvitationDto, UpdateInvitationDto, ReadInvitationDto>, IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvitationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
        }
    }















}
