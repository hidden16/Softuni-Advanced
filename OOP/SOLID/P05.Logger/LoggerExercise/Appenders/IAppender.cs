namespace LoggerExercise.Appenders
{
    using Layouts;
    using ReportLevels;
    public interface IAppender
    {
        int MessageCount { get; }
        ReportLevel ReportLevel { get; set; }
        ILayout Layout { get; }
        void Append(ReportLevel reportLevel, string message);
    }
}
