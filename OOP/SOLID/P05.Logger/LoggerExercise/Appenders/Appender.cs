namespace LoggerExercise.Appenders
{
    using Layouts;
    using ReportLevels;
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ReportLevel ReportLevel { get; set; }
        public ILayout Layout { get; }

        public int MessageCount { get; protected set; }

        public abstract void Append(ReportLevel reportLevel, string message);
        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.GetType().Name}, Messages appended: {MessageCount}";
        }
    }
}
