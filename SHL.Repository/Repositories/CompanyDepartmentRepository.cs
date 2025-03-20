using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class CompanyDepartmentRepository : GenericRepository<CompanyDepartment>, ICompanyDepartmentRepository
    {
        public CompanyDepartmentRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }
    }
}
