using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IContactService : IGenericService<Contact, CreateContactDto, UpdateContactDto, ReadContactDto> {}
}
