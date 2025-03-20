using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.ViewModels;
using System.Security.Principal;

namespace SHL.Repository.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly UserManager<CompanyUser> userManager;

        public StaffRepository(IUnitOfWork context, ICacheManager cacheManager,
            UserManager<CompanyUser> userManager) : base(context, cacheManager)
        {
            this.userManager = userManager;
        }

        public async Task<StaffProfileViewModel?> ProfileAsync(string subjectId)
        {
            var user = _context.Set<CompanyUser>();
            var bank = _context.Set<StaffBank>();
            var profile = await (from s in _dbSet
                                 join u in user on s.CompanyUserId equals u.Id
                                 join b in bank on s.Id equals b.StaffId into staffBank
                                 where u.Id == subjectId
                                 from sb in staffBank.DefaultIfEmpty()
                                 select new StaffProfileViewModel
                                 {
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     StaffCode = s.StaffCode,
                                     StaffDepartment = s.StaffDepartment,
                                     StaffGrade = s.StaffGrade,
                                     CscsNumber = s.CscsNumber,
                                     ChnNumber = s.ChnNumber,
                                     PhoneNumber = u.PhoneNumber,
                                     AccountName = sb != null ? sb.AccountName : "",
                                     BankName = sb != null ? sb.BankName : "",
                                     AccountNumber = sb != null ? sb.AccountNumber : "",
                                     EmailAddress = u.Email,
                                     StaffStatus = u.StaffStatus
                                 }).FirstOrDefaultAsync();

            return profile;
        }

        public async Task<StaffProfileViewModel?> ProfileByEmailAddressAsync(string emailAddress)
        {
            var user = _context.Set<CompanyUser>();
            var bank = _context.Set<StaffBank>();

            var profile = await (from s in _dbSet
                                 join u in user on s.CompanyUserId equals u.Id
                                 join b in bank on s.Id equals b.StaffId into staffBank
                                 where u.NormalizedEmail == emailAddress.ToUpperInvariant()
                                 from sb in staffBank.DefaultIfEmpty()
                                 select new StaffProfileViewModel
                                 {
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     StaffCode = s.StaffCode,
                                     StaffDepartment = s.StaffDepartment,
                                     StaffGrade = s.StaffGrade,
                                     CscsNumber = s.CscsNumber,
                                     ChnNumber = s.ChnNumber,
                                     PhoneNumber = u.PhoneNumber,
                                     AccountName = sb != null ? sb.AccountName : "",
                                     BankName = sb != null ? sb.BankName : "",
                                     AccountNumber = sb != null ? sb.AccountNumber : "",
                                     EmailAddress = u.Email,
                                     StaffStatus = u.StaffStatus

                                 }).FirstOrDefaultAsync();

            return profile;
        }

        public async Task<List<StaffProfileViewModel>> CompanyStaffsAsync(Guid companyId)
        {
            var user = _context.Set<CompanyUser>();
            var bank = _context.Set<StaffBank>();
           // var role = _context.Set<IdentityRole>();
           // var userRole = _context.Set<IdentityUserRole<string>>();

            var staffs = await (from s in _dbSet
                                join u in user on s.CompanyUserId equals u.Id
                                join b in bank on s.Id equals b.StaffId into staffBank                               
                                where s.CompanyId == companyId
                                from sb in staffBank.DefaultIfEmpty()
                                select new StaffProfileViewModel
                                {                                   
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    StaffCode = s.StaffCode,
                                    StaffDepartment = s.StaffDepartment,
                                    StaffGrade = s.StaffGrade,
                                    CscsNumber = s.CscsNumber,
                                    ChnNumber = s.ChnNumber,
                                    PhoneNumber = u.PhoneNumber,
                                    AccountName = sb != null ? sb.AccountName : "",
                                    BankName = sb != null ? sb.BankName : "",
                                    AccountNumber = sb != null ? sb.AccountNumber : "",
                                    EmailAddress = u.Email,
                                    StaffStatus = u.StaffStatus,
                                    IsAdmin = u.IsAdmin
                                }).ToListAsync();
            //foreach (var staff in staffs)
            //{
            //    var roles = await userManager.GetRolesAsync((await userManager.FindByIdAsync(staff.Id)));
            //    staff.IsAdmin = roles.Contains(Role)
            //}
            return staffs;
        }

        public async Task<string> UpdateStaffInfoAsync(UpdateEmployeeDto dto, CancellationToken cancellation)
        {
            var user = await userManager.FindByEmailAsync(dto.EmailAddress);
            if (user is null)
            {
                ApiException.ClientError("Staff with email not found");
                return "";
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;


            await _dbSet.Where(u => u.CompanyUserId == user.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.StaffGrade, dto.StaffGrade)
                .SetProperty(u => u.StaffDepartment, dto.StaffDepartment)
                .SetProperty(u => u.CscsNumber, dto.CscsNumber)
                .SetProperty(u => u.ChnNumber, dto.ChnNumber)
                .SetProperty(s=>s.StaffCode,dto.StaffCode),
                cancellation);

          //  await userManager.UpdateAsync(user);

            return user.Id;
        }


    }
}
