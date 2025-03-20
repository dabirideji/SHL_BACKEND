using SHL.Application.DTO.AppSetting;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class AppSettingRepository : GenericRepository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

       
    }
}
