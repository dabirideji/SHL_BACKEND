using SHL.Application.IServices;
using SHL.Application.Models;
using System.Threading.Channels;

namespace SHL.Infrastructure.Services
{
    public class OfferEmailChannel : IOfferEmailChannel
    {
        public int Capacity { get; set; } = 10000;

        private readonly Channel<EmailModel> _channel;

        public OfferEmailChannel()
        {
            // Create a bounded channel with a specified capacity
            _channel = Channel.CreateBounded<EmailModel>(new BoundedChannelOptions(Capacity)
            {
                FullMode = BoundedChannelFullMode.Wait // Wait when full
            });
        }

        public async ValueTask QueueItemAsync(EmailModel item)
        {
            await _channel.Writer.WriteAsync(item);
        }

        public IAsyncEnumerable<EmailModel> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
