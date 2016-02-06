namespace VehiclePark.Core
{
    using System;
    using Interfaces;

    internal class Engine : IEngine
    {
        private readonly ICommandExecutor commandExecuter;
        private readonly IUserInterface userInterface;

        public Engine(ICommandExecutor commandExecuter, IUserInterface userInterface)
        {
            this.commandExecuter = commandExecuter;
            this.userInterface = userInterface;
        }

        public void Run()
        {
            var commandResult = string.Empty;
            while (true)
            {
                var commandLine = this.userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                if (string.IsNullOrWhiteSpace(commandLine))
                {
                    continue;
                }

                try
                {
                    commandResult = this.commandExecuter.ExecuteCommand(commandLine);
                }
                catch (Exception ex)
                {
                    commandResult = ex.Message;
                }
                finally
                {
                    this.userInterface.WriteLine(commandResult);
                }
            }
        }
    }
}