using Logger;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static ILoggable Logger { get; set; }

        static void Main(string[] args)
        {

            //based on the configuration you need, you assign your type of log
            Logger = new Log2Console(LogLevel.Info);

            Logger.LogMessage("Testing our logger here!");

            Console.Read();
        }
    }
}
