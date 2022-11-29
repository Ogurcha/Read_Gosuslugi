using System;

namespace ReadGosuslugi.Core.Logging
{
    public class LogItem
    {
        public DateTime Date { get; set; }

        public string CategoryName { get; set; }

        public string UserName { get; set; }

        public LogTypeEnum LogType { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }

    public enum LogTypeEnum
    {
        err,
        wrn,
        info,
        debug
    }
}
