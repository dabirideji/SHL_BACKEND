using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
   public interface IUserIdentityService
    {
        string EmailAddress { get; }
        Guid SubjectId { get; }
        string FirstName { get; }
        string LastName { get; }
        string PhoneNumber { get; }
        Guid CompanyId { get; }
    }
}
