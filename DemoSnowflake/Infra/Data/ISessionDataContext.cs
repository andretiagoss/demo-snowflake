using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DemoSnowflake.Infra.Data
{
    public interface ISessionDataContext : IDisposable
    {
        IDbConnection GetDbConnection();
        DbTransaction BeginTransaction();
        IEnumerable<T> Query<T>(string sql, object param = null);
        T QuerySingleOrDefault<T>(string sql, object param = null);
        T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null);
        bool Execute(string sql, object param = null);
    }
}
