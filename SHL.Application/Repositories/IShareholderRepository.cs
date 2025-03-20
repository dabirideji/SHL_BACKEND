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
    public interface IShareholderRepository : IGenericRepository<Shareholder>
    {
        Task<ShareholderViewModel?> GetShareholderByEmailAsync(string emailAddress);
    }
}
