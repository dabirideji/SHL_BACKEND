using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface ISubscriptionService : IGenericService<Subscription, CreateSubscriptionDto, UpdateSubscriptionDto, ReadSubscriptionDto> {}
}
