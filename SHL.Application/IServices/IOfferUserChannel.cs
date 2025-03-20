using SHL.Application.Models;

namespace SHL.Application.IServices
{
    public interface IOfferUserChannel
    {
        ValueTask QueueItemAsync(StaffModel item);
        IAsyncEnumerable<StaffModel> ReadAllAsync();
    }
}
