using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IOptionPoolApprovalService : IGenericService<OptionPoolApproval, CreateOptionPoolApprovalDto, UpdateOptionPoolApprovalDto, ReadOptionPoolApprovalDto> {}
}
