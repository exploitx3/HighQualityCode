using System;
using System.Text;
using Logger.Enum;
using Logger.Interfaces;

namespace Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string LayoutFormat(string message, ReportLevel reportLevel)
        {
            StringBuilder layoutMessage = new StringBuilder();
            DateTime currentDate = new DateTime();

            layoutMessage.AppendFormat("{0} - {1} - {2}", currentDate, reportLevel, message);
            
            return layoutMessage.ToString();
        }
    }
}