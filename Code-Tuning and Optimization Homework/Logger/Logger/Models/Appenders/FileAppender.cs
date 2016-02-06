using System;
using System.IO;
using Logger.Enum;
using Logger.Interfaces;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout layoutFormat;
        private string outputFileName;

        public FileAppender(ILayout layout, ReportLevel reportThreshold = ReportLevel.Info, string outputFileName = "output.txt")
        {
            this.layoutFormat = layout;
            this.ReportThreshold = reportThreshold;
            this.outputFileName = outputFileName;
        }

        public ReportLevel ReportThreshold { get; set; }

        public string File
        {
            get { return this.outputFileName; }
            set { this.outputFileName = value; }
        }

        public void OutputMessage(string message, ReportLevel reportLevel)
        {
            if (reportLevel >= this.ReportThreshold)
            {
                using (StreamWriter writer = new StreamWriter(this.outputFileName, true))
                {
                    writer.WriteLine(this.layoutFormat.LayoutFormat(message, reportLevel));
                }
            }
        }
    }
}