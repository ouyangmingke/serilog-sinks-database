using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Database.Sinks.Database.Entitys;
using SqlSugar;
using System;

namespace Serilog.Sinks.Database.Sinks.Database
{
    public class DatabaseAuditSink : ILogEventSink, IDisposable
    {
        public DatabaseAuditSink(DatabaseSinkOptions databaseSinkOptions)
        {
            CreateSqlConnection(databaseSinkOptions);
            CreateTable();
        }
        public void Emit(LogEvent logEvent)
        {
            SqlSugarHelper.Db.Insertable(new SystemLog()
            {
                LogType = SqlSugarHelper.Db.GetHashCode(),
                Level = logEvent.Level,
                TimeStamp = logEvent.Timestamp.DateTime,
                Exception = logEvent.Exception?.Message ?? "",
                Message = logEvent.RenderMessage()
            }).ExecuteCommand();
        }

        private void CreateSqlConnection(DatabaseSinkOptions DatabaseSinkOptions)
        {
            SqlSugarHelper.Db = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = DatabaseSinkOptions.ConnectionString,//连接符字串
                DbType = DatabaseSinkOptions.DbType,//数据库类型
                IsAutoCloseConnection = true //不设成true要手动close
            }); ;
        }
        private void CreateTable()
        {
            SqlSugarHelper.Db.CodeFirst.InitTables(typeof(SystemLog));
        }
        public void Dispose()
        {
            Console.WriteLine("关闭 DatabaseAuditSink");
            SqlSugarHelper.Db.Dispose();
        }
    }
}
