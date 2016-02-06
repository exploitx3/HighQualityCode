using System;
using Logger.Enum;
using Logger.Interfaces;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layoutFormat;

        public ConsoleAppender(ILayout layout, ReportLevel reportThreshold = ReportLevel.Info)
        {
            this.layoutFormat = layout;
            this.ReportThreshold = reportThreshold;
        }

        public ReportLevel ReportThreshold { get; set; }

        public void OutputMessage(string message, ReportLevel reportLevel)
        {
            if (reportLevel >= this.ReportThreshold)
            {
                Console.WriteLine(this.layoutFormat.LayoutFormat(message, reportLevel));
            }
        }
    }
}