using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class EmploymentDetailService : GenericService<EmploymentDetail, CreateEmploymentDetailDto, UpdateEmploymentDetailDto, ReadEmploymentDetailDto>, IEmploymentDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmploymentDetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
        }
    }















}
