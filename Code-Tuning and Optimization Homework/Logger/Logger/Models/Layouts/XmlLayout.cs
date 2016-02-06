using System;
using System.Text;
using Logger.Enum;
using Logger.Interfaces;

namespace Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string LayoutFormat(string message, ReportLevel reportLevel)
        {
            StringBuilder layoutMessage = new StringBuilder();
            DateTime currentDate = new DateTime();

            layoutMessage.Append("<log>" + Environment.NewLine);
            layoutMessage.AppendFormat(
                "\t<date>{0}</date>{1}\t<level>{2}</level>{3}\t<message>{4}</message>{5}",
                currentDate,
                Environment.NewLine,
                reportLevel,
                Environment.NewLine,
                message,
                Environment.NewLine);
            layoutMessage.Append("</log>");

            return layoutMessage.ToString();
        }
    }
}