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
  public  class BulkEmployeeChannel : IBulkEmployeeChannel
    {
        public int Capacity { get; set; } = 10000;

        private readonly Channel<BulkCreateEmployeeModel> _channel;
        public BulkEmployeeChannel()
        {
            // Create a bounded channel with a specified capacity
            _channel = Channel.CreateBounded<BulkCreateEmployeeModel>(new BoundedChannelOptions(Capacity)
            {
                FullMode = BoundedChannelFullMode.Wait // Wait when full
            });
        }
        public async ValueTask QueueItemAsync(BulkCreateEmployeeModel item)
        {
            await _channel.Writer.WriteAsync(item);
        }

        public IAsyncEnumerable<BulkCreateEmployeeModel> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
