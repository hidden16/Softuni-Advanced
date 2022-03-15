
namespace LoggerExercise.Appenders
{
using System;
using Layouts;
using ReportLevels;
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(ReportLevel reportLevel, string message)
        {
            MessageCount++;
            Console.WriteLine(string.Format(Layout.Format,
                DateTime.Now, 
                reportLevel,
                message));
        }
    }
}
