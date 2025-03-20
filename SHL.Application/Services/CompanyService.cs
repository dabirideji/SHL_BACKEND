using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.DTO.Company.Response;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class CompanyService : GenericService<Company, CreateCompanyDto, UpdateCompanyDto, ReadCompanyDto>, ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
