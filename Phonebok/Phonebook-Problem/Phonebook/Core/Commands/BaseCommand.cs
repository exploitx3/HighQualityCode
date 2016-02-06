namespace Phonebook.Core.Commands
{
    using Interfaces;

    public abstract class BaseCommand : ICommand
    {
        protected readonly IPhonebookRepository PhonebookRepository;
        protected string[] commandArguments;

        protected BaseCommand(IPhonebookRepository phonebookRepository, string[] commandArguments)
        {
            this.PhonebookRepository = phonebookRepository;
            this.commandArguments = commandArguments;
        }

        public abstract string Execute();
    }
}