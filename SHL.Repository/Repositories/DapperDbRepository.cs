using Microsoft.Data.SqlClient;
using System.Data;
using SHL.Application.Interfaces;
using Dapper;

namespace SHL.Repository.Repository
{
    public class DapperDbRepository : IDbRepository, IDisposable
    {
        private readonly IDbConnectionAccessor _dbConnectionAccessor;
        private SqlConnection _dbClient;

        public DapperDbRepository(IDbConnectionAccessor dbConnectionAccessor)
        {
            _dbConnectionAccessor = dbConnectionAccessor;
        }

        public async Task<List<dynamic>> RunMultipleQueriesSequentialAsync(List<(string query, object parameters)> queries)
        {
            if (_dbClient == null || _dbClient.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("Connection is not open.");
            }
            var results = new List<dynamic>();

            foreach (var query in queries)
            {
                try
                {
                    var result = await _dbClient.QueryAsync<dynamic>(query.query, query.parameters);
                    results.Add(result);
                }
                catch (Exception ex)
                {
                    results.Add(new { Error = ex.Message });
                }
            }
            return results;
        }

        public async Task CreateConnectionAsync(string clientId)
        {
            var connectionString = _dbConnectionAccessor.GetConnectionString(clientId);
            _dbClient = new SqlConnection(connectionString);
            await _dbClient.OpenAsync();
        }

        public async Task<T> RunQueryAsync<T>(string query, object parameters = null)
        {
            if (_dbClient == null || _dbClient.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection is not open.");

            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query cannot be null or empty.");

            return await _dbClient.QueryFirstOrDefaultAsync<T>(query, parameters);
        } 
        
        public async Task<IEnumerable<T>> RunQueryListAsync<T>(string query, object parameters = null)
        {
            if (_dbClient == null || _dbClient.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection is not open.");

            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query cannot be null or empty.");

            return await _dbClient.QueryAsync<T>(query, parameters);
        }
        
        public async Task<List<dynamic>> RunMultipleQueriesInParallelAsync(List<(string query, object parameters)> queries)
        {
            if (_dbClient == null || _dbClient.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection is not open.");

            var tasks = new List<Task<dynamic>>();
            foreach (var queryTuple in queries)
            {
                tasks.Add(RunQueryAsync(queryTuple.query, queryTuple.parameters));
            }
            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        private async Task<dynamic> RunQueryAsync(string query, object parameters)
        {
            try
            {
                var queryParameters = parameters ?? new { };
                return await _dbClient.QueryAsync<dynamic>(query, queryParameters);
            }
            catch (Exception ex)
            {
                return new { Error = ex.Message };
            }
        }
        public void Dispose()
        {
            _dbClient?.Dispose();
        }
    }
}