using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.DTO;

namespace SHL.Application.IServices
{
    public interface IEStockService
    {
        Task<List<IdNameObj>> GetMyRegistrarsAsync(string email);
        Task<List<IdNameObj>> GetEquityRegistrarsAsync();
        Task<List<IdTextObj>> GetMyAccountsAsync(string email);
        Task<List<IdTextObj>> GetAllMyAccountsAsync(string email);
        Task<List<IdNameObj>> GetRegistrarsAsync();
    }
}
