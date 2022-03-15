namespace LoggerExercise.Loggers
{
    using Appenders;
    using ReportLevels;
    public interface ILogger
    {
        ReportLevel ReportLevel { get; }
        public IAppender[] Appenders { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Fatal(string message);
    }
}
