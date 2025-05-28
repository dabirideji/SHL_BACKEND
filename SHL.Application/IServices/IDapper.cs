using Dapper;
using System.Data;
using System.Data.Common;
using static Dapper.SqlMapper;

namespace SHL.Application.IServices
{
    public interface IDapper : IDisposable
    {
        //https://code-maze.com/using-dapper-with-asp-net-core-web-api/

        //Create Connection String
        DbConnection GetDbconnection(string? connectionString = null);

        //Get a record.
        Task<T> GetAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Get list of records.
        Task<List<T>> GetAllAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null, int? connectionTimeout = null);

        //Execute Querry and return DataSet or DataTable.
        Task<GridReader> GetMultipleResultAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return scope Identity.
        Task<int> QuerySingleAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return single response object.
        Task<T> QuerySingleAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return single response object or null record if not available
        Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute querry and return number of affected rows count.
        Task<int> ExecuteAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        //Execute multiple insert querry and return number of affected rows count.
        Task ExecuteMultipleAsync(string procedureName, List<DynamicParameters> parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null);

        Task SqlBulkCopy(DataTable dataTable, string tableName, string? connectionString = null);
    }
}
