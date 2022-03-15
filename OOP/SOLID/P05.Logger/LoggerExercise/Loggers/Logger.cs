namespace LoggerExercise.Loggers
{
using Appenders;
using ReportLevels;
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }
        public IAppender[] Appenders { get; }

        public ReportLevel ReportLevel { get; }

        public void Info(string message)
        {
            Log(ReportLevel.Info, message);
        }
        public void Warning(string message)
        {
            Log(ReportLevel.Warning, message);
        }
        public void Error(string message)
        {
            Log(ReportLevel.Error, message);
        }
        public void Critical(string message)
        {
            Log(ReportLevel.Critical, message);
        }
        public void Fatal(string message)
        {
            Log(ReportLevel.Fatal, message);
        }
        private void Log(ReportLevel reportLevel, string message)
        {
            foreach (var append in Appenders)
            {
                if (reportLevel >= append.ReportLevel)
                {
                    append.Append(reportLevel, message);
                }
            }
        }

    }
}
