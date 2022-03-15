
namespace LoggerExercise
{
    using System;
    using System.IO;
    using Appenders;
    using Layouts;
    using LogFiles;
    using ReportLevels;

    public class FileAppender : Appender
    {
        readonly ILogFile logFile;
        readonly string path;
        public FileAppender(ILayout layout,
            ILogFile logFile,
            string path)
            : base(layout)
        {
            this.logFile = logFile;
            this.path = path;
        }

        public override void Append(ReportLevel reportLevel, string message)
        {
            var outputMessage = string.Format(Layout.Format, DateTime.Now,
                                reportLevel,
                                message);
            logFile.Write(outputMessage);
            MessageCount++;
            File.AppendAllText(path, outputMessage + Environment.NewLine);
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {logFile.Size()}";
        }
    }
}
