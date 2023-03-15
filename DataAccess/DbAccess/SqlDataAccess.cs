using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

using System.Data;
using Dapper;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure,
                                    U parameters, string connnectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connnectionId));

            return await connection.QueryAsync<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task SaveData<T>(string storeProcedure,
                                    T parameters, string connnectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connnectionId));

            await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
