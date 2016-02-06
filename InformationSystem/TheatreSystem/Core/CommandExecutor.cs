namespace TheatreSystem.Core
{
    using System;
    using System.Linq;
    using Commands;
    using Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly IPerformanceDatabase performanceDatabase;

        public CommandExecutor(IPerformanceDatabase performanceDatabase)
        {
            this.performanceDatabase = performanceDatabase;
        }

        public void ExecuteCommand(string inputLine)
        {
            string[] commandLine = inputLine.Split('(');
            string commandName = commandLine[0];

            string[] commandArgumentsArray =
                commandLine[1]
                .Split(
                    new[] { '(', ',', ')' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToArray();

            ICommand command = null;
            switch (commandName)
            {
                case "AddTheatre":
                    command = new AddTheatreCommand(commandArgumentsArray, this.performanceDatabase);
                    break;
                case "PrintAllTheatres":
                    command = new PrintAllTheatersCommand(commandArgumentsArray, this.performanceDatabase);
                    break;
                case "AddPerformance":
                    command = new AddPerformanceCommand(commandArgumentsArray, this.performanceDatabase);
                    break;
                case "PrintAllPerformances":
                    command = new PrintAllPerformancesCommand(commandArgumentsArray, this.performanceDatabase);
                    break;
                case "PrintPerformances":
                    command = new PrintPerformancesCommand(commandArgumentsArray, this.performanceDatabase);
                    break;
                default:
                    throw new NotImplementedException("The command with name " + commandName + " is not defined/implemented.");
            }

            string commandResult;
            try
            {
                commandResult = command.Execute();
            }
            catch (Exception ex)
            {
                commandResult = "Error: " + ex.Message;
            }

            Console.WriteLine(commandResult);
        }
    }
}