using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IPayoutAccountService : IGenericService<PayoutAccount, CreatePayoutAccountDto, UpdatePayoutAccountDto, ReadPayoutAccountDto> {}
}
