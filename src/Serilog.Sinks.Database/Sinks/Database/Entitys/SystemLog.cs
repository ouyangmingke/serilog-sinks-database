using Serilog.Events;
using System;

namespace Serilog.Sinks.Database.Sinks.Database.Entitys
{
    public class SystemLog
    {
        public int Id { get; set; }
        public int LogType { get; set; }
        public int LogCode { get; set; }
        public string Message { get; set; }
        public LogEventLevel Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
    }
}
