namespace Phonebook.Core
{
    using System;
    using Commands;
    using Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly IPhonebookRepository phonebookRepository;

        public CommandExecutor(IPhonebookRepository phonebookRepository)
        {
            this.phonebookRepository = phonebookRepository;
        }

        public string ExecuteCommand(string commandName, string[] commandArguments)
        {
            ICommand command = null;
            if (commandName == "AddPhone" && commandArguments.Length >= 2)
            {
                command = new AddPhoneCommand(this.phonebookRepository, commandArguments);
            }
            else if (commandName == "ChangePhone" && commandArguments.Length == 2)
            {
                command = new ChangePhoneCommand(this.phonebookRepository, commandArguments);
            }
            else if (commandName == "List" && commandArguments.Length == 2)
            {
                command = new ListCommand(this.phonebookRepository, commandArguments);
            }
            else
            {
                return "Invalid command";
            }

            string commandResult;
            try
            {
                commandResult = command.Execute();
            }
            catch (Exception e)
            {
                commandResult = e.Message;

            }
            
            return commandResult;
        }
    }
}