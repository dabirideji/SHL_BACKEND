using Dapper;
using Microsoft.Extensions.Logging;
using SHL.Application.Constants;
using SHL.Application.IServices;
using SHL.Application.DTO.ViewDto;
using SHL.Models.DTO;

namespace SHL.Infrastructure.Services
{
    public class EStockService: IEStockService
    {
        private readonly ILogger<EStockService> logger;
        private readonly IDapper _dapper;
        public EStockService(ILogger<EStockService> logger, IDapper dapper)
        {
            this.logger = logger;
            _dapper = dapper;
        }
        public async Task<List<IdNameObj>> GetEquityRegistrarsAsync()
        {
            try
            {
               var rams = new DynamicParameters();
               return await _dapper.GetAllAsync<IdNameObj>(ProcedureConstraint.FetchEquityCompanies,rams);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<IdNameObj>();
            }
        }

        public async Task<List<IdNameObj>> GetMyRegistrarsAsync(string email)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                return await _dapper.GetAllAsync<IdNameObj>(ProcedureConstraint.FetchMyCompanies, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<IdNameObj>();
            }
        }

        public async Task<List<IdTextObj>> GetMyAccountsAsync(string email)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                return await _dapper.GetAllAsync<IdTextObj>(ProcedureConstraint.FetchMyAccounts, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<IdTextObj>();
            }
        }

        public async Task<List<IdTextObj>> GetAllMyAccountsAsync(string email)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                return await _dapper.GetAllAsync<IdTextObj>(ProcedureConstraint.FetchAllMyAccounts, parameters);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<IdTextObj>();
            }
        }

        public async Task<List<IdNameObj>> GetRegistrarsAsync()
        {
            try
            {
                const string sql = "SELECT coy_no AS Id, coy_name AS Name FROM VwTRegNames";
                var connection = _dapper.GetDbconnection();
                var result = await connection.QueryAsync<IdNameObj>(sql);
                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<IdNameObj>();
            }
        }
        public async Task<IdNameObj> GetDefaultCompany(string email)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);

                var result = await _dapper.GetAllAsync<IdNameObj>("[dbo].[fetchMyDefaultCompany]", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching default company for {Email}", email);
                return null;
            }
        }

        public async Task<vwUserObj> FetchMyProfile(string email, int companyId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@companyId", companyId);

                var result = await _dapper.GetAllAsync<vwUserObj>("[dbo].[getMyProfile]", parameters);
                var profile = result.FirstOrDefault();

                if (profile != null)
                {
                   // profile.account_details =  FetchBankInfos(email); 
                }

                return profile;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching profile for {Email}", email);
                return null;
            }
        }
        public async Task<List<IdNameObj>> GetCompanies()
        {
            try
            {
                var parameters = new DynamicParameters();
                var result = await _dapper.GetAllAsync<IdNameObj>("[dbo].[fetchEquityCompanies]",parameters);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching companies");
                return null;
            }
        }

    }
}
