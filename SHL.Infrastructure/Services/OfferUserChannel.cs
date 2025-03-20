using SHL.Application.IServices;
using SHL.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SHL.Infrastructure.Services
{
   public class OfferUserChannel: IOfferUserChannel
    {
        private readonly Channel<StaffModel> _channel;

        public OfferUserChannel(int capacity = 10000)
        {
            // Create a bounded channel with a specified capacity
            _channel = Channel.CreateBounded<StaffModel>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait // Wait when full
            });
        }

        public async ValueTask QueueItemAsync(StaffModel item)
        {
            await _channel.Writer.WriteAsync(item);
        }

        public IAsyncEnumerable<StaffModel> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
