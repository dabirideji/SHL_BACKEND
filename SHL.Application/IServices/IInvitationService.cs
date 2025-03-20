using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IInvitationService : IGenericService<Invitation, CreateInvitationDto, UpdateInvitationDto, ReadInvitationDto> {}
}
