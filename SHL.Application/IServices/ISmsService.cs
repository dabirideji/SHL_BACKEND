using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string recipient, string message);
    }
}
