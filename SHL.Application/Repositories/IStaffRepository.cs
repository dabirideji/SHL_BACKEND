using SHL.Application.DTO.Company;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.ViewModels;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Repositories
{
   public interface IStaffRepository:IGenericRepository<Staff>
    {
        Task<StaffProfileViewModel?> ProfileByEmailAddressAsync(string emailAddress);
        Task<StaffProfileViewModel?> ProfileAsync(string subjectId);
        Task<List<StaffProfileViewModel>> CompanyStaffsAsync(Guid companyId);
        Task<string> UpdateStaffInfoAsync(UpdateEmployeeDto dto, CancellationToken cancellation);
    }
}
