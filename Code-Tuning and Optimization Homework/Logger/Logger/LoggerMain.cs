using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Enum;
using Logger.Interfaces;
using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Layouts;

namespace Logger
{
    class LoggerMain
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportThreshold = ReportLevel.Error;

            var logger = new Models.Loggers.Logger(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
