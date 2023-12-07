using SqlSugar;

namespace Serilog.Sinks.Database.Sinks.Database
{
    public class DatabaseSinkOptions
    {
        public DatabaseSinkOptions(string connectionString, DbType dbType)
        {
            ConnectionString = connectionString;
            DbType = dbType;
        }
        public string ConnectionString { get; set; }

        public DbType DbType { get; set; }
    }
}
