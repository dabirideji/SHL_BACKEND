using SHL.Application.IManagers;
using SHL.Application.Repositories;
using SHL.Domain.Models;
using SHL.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SHLTennantDbContext context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }
    }
}
