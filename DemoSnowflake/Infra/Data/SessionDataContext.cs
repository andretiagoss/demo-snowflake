using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DemoSnowflake.Infra.Data
{
    public class SessionDataContext : ISessionDataContext
    {
        private readonly DbConnection _dbConnection;
        public SessionDataContext(IConnectionFactory connectionFactory)
        {
            _dbConnection = connectionFactory.Connection();
        }
        
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return GetDbConnection().Query<T>(sql, param);
        }

        public T QuerySingleOrDefault<T>(string sql, object param = null)
        {
            return GetDbConnection().QuerySingleOrDefault<T>(sql, param);
        }
        public void Dispose()
        {
            if (_dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();
        }

        public DbTransaction BeginTransaction()
        {
            return _dbConnection.BeginTransaction();
        }

        public IDbConnection GetDbConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();

            return _dbConnection;
        }

        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null)
        {
            return GetDbConnection().ExecuteScalar<T>(sql, param, transaction);
        }

        public bool Execute(string sql, object param = null)
        {
            var result = GetDbConnection().Execute(sql, param);
            return result == 1;
        }
    }
}
