using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.Identity;


namespace SHL.Application.IServices
{
    public interface ITokenServices
    {
        ValueTask<string> CreateTokenAsync(ApplicationUser user);
    }
}
