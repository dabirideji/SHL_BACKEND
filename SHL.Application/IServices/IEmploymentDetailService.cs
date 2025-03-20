using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IEmploymentDetailService : IGenericService<EmploymentDetail, CreateEmploymentDetailDto, UpdateEmploymentDetailDto, ReadEmploymentDetailDto> {}
}
