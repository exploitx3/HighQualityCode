namespace TheatreSystem
{
    using Core;
    using Interfaces;
    using Models;

    public class TheatreMain
    {
        internal static void Main(string[] args)
        {
            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();
            ICommandExecutor commandExecutor = new CommandExecutor(performanceDatabase);
            IEngine engine = new TheatreEngine(commandExecutor);

            engine.Run();
        }
    }
}