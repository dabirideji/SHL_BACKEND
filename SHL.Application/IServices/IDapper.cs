using Dapper;
using System.Data;
using System.Data.Common;
using static Dapper.SqlMapper;

namespace SHL.Application.IServices
{
    public interface IDapper : IDisposable
    {
        //https://code-maze.com/using-dapper-with-asp-net-core-web-api/

        DbConnection GetDbconnection(string? connectionString = null);

        Task<T> GetAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);
        Task<List<T>> GetAllAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null, int? connectionTimeout = null);
        Task<GridReader> GetMultipleResultAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return scope Identity.
      //  Task<int> QuerySingleAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return single response object.
        Task<T> QuerySingleAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);
        Task<int> ExecuteAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);
        Task ExecuteMultipleAsync(string procedureName, List<DynamicParameters> parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);
        Task SqlBulkCopy(DataTable dataTable, string tableName, string? connectionString = null);
    }
}
