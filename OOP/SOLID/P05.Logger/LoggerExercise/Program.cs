
namespace LoggerExercise
{
    using System;
    using System.Collections.Generic;
    using Appenders;
    using Factories;
    using Layouts;
    using Loggers;
    using ReportLevels;
    public class Program
    {
        static void Main(string[] args)
        {
            List<IAppender> appenders = new List<IAppender>();
            int n = int.Parse(Console.ReadLine());
            ILayout layout;
            IAppender appender;
            for (int i = 0; i < n; i++)
            {
                var cmds = Console.ReadLine().Split();
                var appenderType = cmds[0];
                var layoutType = cmds[1];
                ReportLevel reportLevel = cmds.Length == 3
                    ? Enum.Parse<ReportLevel>(cmds[2], true)
                    : ReportLevel.Info;
                layout = LayoutFactory.CreateLayout(layoutType);
                appender = AppenderFactory.CreateAppender(appenderType,
                    layout, 
                    reportLevel);
                appenders.Add(appender);
            }
            ILogger logger =
              new Logger(appenders.ToArray());
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var tokens = commands.Split('|');
                ReportLevel reportLevel
                     = Enum.Parse<ReportLevel>(tokens[0], true);
                var messagge = tokens[2];
                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(messagge);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(messagge);
                        break;
                    case ReportLevel.Error:
                        logger.Error(messagge);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(messagge);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(messagge);
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine("Logger info");
            foreach (var item in logger.Appenders)
            {
                Console.WriteLine(item);
            }
        }
    }
}
