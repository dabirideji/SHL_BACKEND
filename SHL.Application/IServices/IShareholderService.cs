using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IShareholderService : IGenericService<Shareholder, CreateShareholderDto, UpdateShareholderDto, ReadShareholderDto> { }
}
