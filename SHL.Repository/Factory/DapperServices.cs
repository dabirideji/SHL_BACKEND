using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SHL.Application.IServices;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Z.Dapper.Plus;
using static Dapper.SqlMapper;

namespace SHL.Repository.Factory
{
    public class DapperServices : IDapper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Dispose()
        {

        }

        public DbConnection GetDbconnection(string? connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _connectionString;
            }
            return new SqlConnection(_configuration.GetConnectionString(connectionString));
        }

        public async Task<T> GetAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null)
        {
            using IDbConnection db = GetDbconnection(connectionString);

            return await db.QuerySingleOrDefaultAsync<T>(procedureName, parameters, commandType: commandType).ConfigureAwait(false);
        }
        public async Task<List<T>> GetAllAsync<T>(string procedureName, DynamicParameters? parameters = null, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null, int? connectionTimeout = null)
        {
            try
            {
                using var dbConnection = GetDbconnection(connectionString);
                var result = await dbConnection.QueryAsync<T>(procedureName, parameters, commandTimeout: connectionTimeout, commandType: commandType).ConfigureAwait(false);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<GridReader> GetMultipleResultAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string? connectionString = null)
        {
            using IDbConnection db = GetDbconnection(connectionString);
            return await db.QueryMultipleAsync(procedureName, parameters, commandType: commandType).ConfigureAwait(false);
        }
        public async Task<int> QuerySingleAsync(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {
            int result;
            using IDbConnection db = GetDbconnection(connectionString);
            if (db.State == ConnectionState.Closed)
                db.Open();

            using var tran = db.BeginTransaction();
            try
            {
                result = await db.QuerySingleAsync(procedureName, parameters, commandType: commandType, transaction: tran).ConfigureAwait(false);
                tran.Commit();
                return result;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                var SerializeReponse = JsonConvert.SerializeObject(ex.InnerException?.Message);
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<T> QuerySingleAsync1<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {
            T result;
            using IDbConnection db = GetDbconnection(connectionString);
            if (db.State == ConnectionState.Closed)
                db.Open();

            using var tran = db.BeginTransaction();
            try
            {
                result = await db.QuerySingleAsync(procedureName, parameters, commandType: commandType, transaction: tran).ConfigureAwait(false);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
             
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }

            return result;
        }

        public async Task<T> QuerySingleAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {
            using var dbConnection = GetDbconnection(connectionString);
            await dbConnection.OpenAsync();

            using var transaction = await dbConnection.BeginTransactionAsync();

            try
            {
                var result = await dbConnection.QuerySingleAsync<T>(procedureName, parameters, commandType: commandType, transaction: transaction).ConfigureAwait(false);
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }


        public async Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {
            T result;
            using IDbConnection db = GetDbconnection(connectionString);
            if (db.State == ConnectionState.Closed)
                db.Open();

            using var tran = db.BeginTransaction();
            try
            {
                result = await db.QueryFirstOrDefaultAsync(procedureName, parameters, commandType: commandType, transaction: tran).ConfigureAwait(false);
                tran.Commit();
                return result;
            }
            catch (Exception ex)
            {
                tran.Rollback();
      
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<int> ExecuteAsync(string procedureName, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {
            using var dbConnection = GetDbconnection(connectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int result;
            using var tran = dbConnection.BeginTransaction();

            try
            {
                result = await dbConnection.ExecuteAsync(procedureName, parameters, commandType: commandType, transaction: tran).ConfigureAwait(false);
                tran.Commit();
                return result;
            }
            catch (Exception ex) when (ex is not null)
            {
                tran.Rollback();
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }


        public async Task ExecuteMultipleAsync(string procedureName, List<DynamicParameters> parameters, CommandType commandType = CommandType.StoredProcedure, string connectionString = null)
        {

            using IDbConnection db = GetDbconnection(connectionString);
            if (db.State == ConnectionState.Closed)
                db.Open();

            using var tran = db.BeginTransaction();
            try
            {
                foreach (var parameter in parameters)
                {
                    await db.ExecuteAsync(procedureName, parameter, commandType: commandType, transaction: tran).ConfigureAwait(false);
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
        public async Task SqlBulkCopy(DataTable dataTable, string tableName, string connecString = null)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString(connecString));
            await conn.OpenAsync();

            using var bulkCopy = new SqlBulkCopy(conn);
            bulkCopy.BulkCopyTimeout = 1;  //SqlTimeoutSeconds;
            bulkCopy.BatchSize = 500;
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.EnableStreaming = true;

            await bulkCopy.WriteToServerAsync(dataTable);
        }
        //Bulk Insert Example
        public int BulkInsert<T>(List<DynamicParameters> parms, string connecString = null)
        {
            int result;
            using (IDbConnection db = GetDbconnection(connecString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var tran = db.BeginTransaction();
                try
                {
                    db.BulkInsert(parms);
                    db.BulkUpdate(parms);
                    db.BulkDelete(parms);
                    db.BulkMerge(parms);
                    result = 1;
                    tran.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    var SerializeReponse = JsonConvert.SerializeObject(parms);
                    throw new Exception(ex.InnerException?.Message ?? ex.Message);
                }
            }
        }
    }
}