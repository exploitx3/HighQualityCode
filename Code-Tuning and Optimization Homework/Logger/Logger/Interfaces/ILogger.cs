namespace Logger.Interfaces
{
    public interface ILogger
    {
        void Info(string message, params object[] arguments);

        void Warn(string message, params object[] arguments);

        void Error(string message, params object[] arguments);

        void Critical(string message, params object[] arguments);

        void Fatal(string message, params object[] arguments);
    }
}