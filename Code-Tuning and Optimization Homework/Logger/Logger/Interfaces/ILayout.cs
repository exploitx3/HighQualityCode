using Logger.Enum;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        string LayoutFormat(string message, ReportLevel reportLevel);
    }
}