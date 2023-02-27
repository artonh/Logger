using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class Log2File : Logger
    {
        public string FileName { get; set; }

        public string DateFormat { get; set; }

        public string FileBasePath { get; set; }
        private string FileNamePath { get; set; }

        public Log2File(LogLevel loggingLevel) : base(loggingLevel)
        {
            FileBasePath = Path.GetFullPath(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Output"));
            DateFormat = "yyyyMMdd";
            FileName = "logs";

            init();
        }

        public Log2File(LogLevel loggingLevel, string fileName, string dateFormat, string fileBasePath) : base(loggingLevel)
        {
            FileName = fileName;
            DateFormat = dateFormat;
            FileBasePath = fileBasePath;

            init();
        }

        /// <param name="loggingLevel">Level of the log</param>
        /// <param name="fileNamePath">Full name of path explicity</param>
        public Log2File(LogLevel loggingLevel, string fileNamePath) : base(loggingLevel)
        {
            if (!string.IsNullOrEmpty(fileNamePath) && fileNamePath.Trim().ToLower().LastIndexOf(".txt") == -1)
            {
                fileNamePath += ".txt";
            }

            FileNamePath = fileNamePath;
        }

        void init()
        {
            FileNamePath = $"{FileBasePath}//{DateTime.Now.ToString(DateFormat)}_{FileName}.txt";
        }

        protected override (LogLevel logLevel, string message) WriteMessage(LogLevel logLevel, string message)
        {
            var CurrentTime = DateTime.Now.ToLongTimeString();

            string patternMessage = $"{CurrentTime}, Type: {logLevel}, Message: {message};";

            Console.WriteLine(patternMessage);
            WriteInFile(patternMessage);

            return (logLevel, patternMessage);
        }

        private void WriteInFile(string message)
        {
            using (StreamWriter w = File.AppendText(FileNamePath))
            {
                w.WriteLine(message);
            }
        }
    }
}
