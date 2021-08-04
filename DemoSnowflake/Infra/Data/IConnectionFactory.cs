using System.Data.Common;

namespace DemoSnowflake.Infra.Data
{
    public interface IConnectionFactory
    {
        DbConnection Connection();
    }
}
