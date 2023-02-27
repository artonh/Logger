using System;

namespace Logger
{
    public interface ILoggable
    {
        (LogLevel logLevel, string message) LogMessage(string message);

        (LogLevel logLevel, string message) LogMessage(LogLevel logLevel, string message);
    }

    public abstract class Logger : ILoggable
    {

        protected LogLevel LoggingLevel
        {
            get;
            set;
        }

        public Logger(LogLevel loggingLevel)
        {
            LoggingLevel = loggingLevel;
        }

        public (LogLevel logLevel, string message) LogMessage(string message)
        {
            return WriteMessage(LogLevel.Info, message);
        }

        public (LogLevel logLevel, string message) LogMessage(LogLevel logLevel, string message)
        {

            if (logLevel <= LoggingLevel)
            {
                return WriteMessage(logLevel, message);
            }
            return default;
        }

        protected abstract (LogLevel logLevel, string message) WriteMessage(LogLevel logLevel, string message);

    }



    public enum LogLevel : int
    {
        Failure = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        Debug = 4,
        Trace = 5
    }
}
