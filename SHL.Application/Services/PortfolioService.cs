using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class PortfolioService : GenericService<Portfolio, CreatePortfolioDto, UpdatePortfolioDto, ReadPortfolioDto>, IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }















}
