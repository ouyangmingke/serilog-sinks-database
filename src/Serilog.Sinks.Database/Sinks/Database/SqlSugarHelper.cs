using SqlSugar;

namespace Serilog.Sinks.Database.Sinks.Database
{
    public class SqlSugarHelper
    {
        public static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig());
    }
}
