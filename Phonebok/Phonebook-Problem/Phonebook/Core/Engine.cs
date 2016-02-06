namespace Phonebook.Core
{
    using System;
    using System.Text;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IInputOutputHandler inputOutputHandler;

        public Engine(ICommandExecutor commandExecutor, IInputOutputHandler inputOutputHandler)
        {
            this.commandExecutor = commandExecutor;
            this.inputOutputHandler = inputOutputHandler;
        }

        public void Run()
        {
            StringBuilder finalResult = new StringBuilder();
            while (true)
            {
                string data = Console.ReadLine();
                if (data == "End" || data == null)
                {
                    // Error reading from console 
                    break;
                }

                int commandSeperatorIndex = data.IndexOf('(');
                if (commandSeperatorIndex == -1)
                {
                    Console.WriteLine("error!"); Environment.Exit(0);
                }

                if (!data.EndsWith(")"))
                {
                    continue;
                }

                string commandName = data.Substring(0, commandSeperatorIndex);
                string commandParametersLine = data.Substring(
                    commandSeperatorIndex + 1,
                    data.Length - commandSeperatorIndex - 2);

                string[] commandParameters = commandParametersLine.Split(',');
                for (int paramIndex = 0; paramIndex < commandParameters.Length; paramIndex++)
                {
                    commandParameters[paramIndex] = commandParameters[paramIndex].Trim();
                }

                var commandResult = this.commandExecutor.ExecuteCommand(commandName, commandParameters);
                finalResult.AppendLine(commandResult);
            }

            this.inputOutputHandler.Write(finalResult.ToString());
        }
    }
}