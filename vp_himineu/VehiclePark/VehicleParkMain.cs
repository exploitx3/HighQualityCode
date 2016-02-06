namespace VehiclePark
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Interfaces;
    using IO;

    internal static class VehicleParkMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ICommandExecutor commandExecutor = new CommandExecuter();
            IUserInterface userInterface = new ConsoleInterface();

            var engine = new Engine(commandExecutor, userInterface);
            engine.Run();
        }
    }
}