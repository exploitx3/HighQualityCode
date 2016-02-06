using System.Text;
using Logger.Enum;
using Logger.Interfaces;

namespace Logger.Models.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string message, params object[] arguments)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat(message, arguments);

            foreach (var appender in this.appenders)
            {
                appender.OutputMessage(message, ReportLevel.Info);
            }
        }

        public void Warn(string message, params object[] arguments)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat(message, arguments);

            foreach (var appender in this.appenders)
            {
                appender.OutputMessage(message, ReportLevel.Warn);
            }
        }

        public void Error(string message, params object[] arguments)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat(message, arguments);

            foreach (var appender in this.appenders)
            {
                appender.OutputMessage(message, ReportLevel.Error);
            }
        }

        public void Critical(string message, params object[] arguments)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat(message, arguments);

            foreach (var appender in this.appenders)
            {
                appender.OutputMessage(message, ReportLevel.Critical);
            }
        }

        public void Fatal(string message, params object[] arguments)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat(message, arguments);

            foreach (var appender in this.appenders)
            {
                appender.OutputMessage(message, ReportLevel.Fatal);
            }
        }
    }
}