using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Log2Console : Logger
    {
        public Log2Console(LogLevel loggingLevel) : base(loggingLevel)
        {
        }

        protected override (LogLevel logLevel, string message) WriteMessage(LogLevel logLevel, string message)
        {
            var CurrentTime = DateTime.Now.ToLongTimeString();

            string patternMessage = $"{CurrentTime}, Type: {logLevel}, Message: {message};";

            Console.WriteLine(patternMessage);
            return (logLevel, message);
        }
    }
}
