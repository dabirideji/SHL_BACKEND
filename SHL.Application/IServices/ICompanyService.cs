using SHL.Application.DTO.Company.Request;
using SHL.Application.DTO.Company.Response;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface ICompanyService : IGenericService<Company, CreateCompanyDto, UpdateCompanyDto, ReadCompanyDto> { }
}
