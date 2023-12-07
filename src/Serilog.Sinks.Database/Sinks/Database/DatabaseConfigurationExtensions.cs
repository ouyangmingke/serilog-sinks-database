using Serilog.Configuration;
using SqlSugar;
namespace Serilog.Sinks.Database.Sinks.Database
{
    public static class DatabaseConfigurationExtensions
    {
        public static LoggerConfiguration Database(this LoggerSinkConfiguration loggerConfiguration,
            string connectionString,
            DbType dbType = DbType.Sqlite
            )
        {
            return loggerConfiguration.Sink(new DatabaseAuditSink(
                new DatabaseSinkOptions(connectionString, dbType)
                ));
        }
    }
}
