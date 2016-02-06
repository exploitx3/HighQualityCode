using Logger.Enum;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        void OutputMessage(string message, ReportLevel reportLevel);
    }
}