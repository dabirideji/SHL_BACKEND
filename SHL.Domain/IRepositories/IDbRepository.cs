namespace SHL.Application.Interfaces
{
    public interface IDbRepository : IDisposable
    {
        /// <summary>
        /// CREATES CONNECTION INSTANCE - SINGLETON
        /// </summary>
        /// <param name="clientId">THE CLIENT ID TO IDENTIFY THE CONNECTION STRING</param>
        /// <returns>A TASK THAT REPRESENTS THE ASYNCHRONOUS OPERATION</returns>
        Task CreateConnectionAsync(string clientId);

        /// <summary>
        /// RUNS A SINGLE QUERY
        /// </summary>
        /// <typeparam name="T">THE EXPECTED RETURN TYPE OF THE QUERY RESULT</typeparam>
        /// <param name="query">THE SQL QUERY TO EXECUTE</param>
        /// <param name="parameters">OPTIONAL QUERY PARAMETERS</param>
        /// <returns>A TASK THAT RETURNS THE FIRST RESULT OF THE QUERY</returns>
        Task<T> RunQueryAsync<T>(string query, object parameters = null);

        Task<IEnumerable<T>> RunQueryListAsync<T>(string query, object parameters = null);

        /// <summary>
        /// RUNS MULTIPLE QUERIES IN PARALLEL
        /// </summary>
        /// <param name="queries">A LIST OF QUERIES AND PARAMETERS TO EXECUTE</param>
        /// <returns>A TASK THAT RETURNS A LIST OF RESULTS FROM ALL QUERIES</returns>
        Task<List<dynamic>> RunMultipleQueriesInParallelAsync(List<(string query, object parameters)> queries);

        /// <summary>
        /// RUNS MULTIPLE QUERIES SEQUENTIALLY
        /// </summary>
        /// <param name="queries">A LIST OF QUERIES AND PARAMETERS TO EXECUTE</param>
        /// <returns>A TASK THAT RETURNS A LIST OF RESULTS EXECUTED IN SEQUENCE</returns>
        Task<List<dynamic>> RunMultipleQueriesSequentialAsync(List<(string query, object parameters)> queries);
    }
}
