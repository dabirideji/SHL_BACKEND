using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class ContactService : GenericService<Contact, CreateContactDto, UpdateContactDto, ReadContactDto>, IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContactService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }   















}
