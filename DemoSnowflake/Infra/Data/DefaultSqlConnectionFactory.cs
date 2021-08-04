using Microsoft.Extensions.Configuration;
using Snowflake.Data.Client;
using System.Data.Common;

namespace DemoSnowflake.Infra.Data
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configurations;

        /// <summary>
        /// </summary>
        /// <param name="configurations"></param>
        public DefaultSqlConnectionFactory(IConfiguration configurations)
        {
            _configurations = configurations;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DbConnection Connection()
        {
            var conn = new SnowflakeDbConnection();
            conn.ConnectionString = _configurations.GetConnectionString("Default");

            return conn;
        }
    }
}
