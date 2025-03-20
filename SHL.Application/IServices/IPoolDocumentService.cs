using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IPoolDocumentService : IGenericService<PoolDocument, CreatePoolDocumentDto, UpdatePoolDocumentDto, ReadPoolDocumentDto> {}
}
