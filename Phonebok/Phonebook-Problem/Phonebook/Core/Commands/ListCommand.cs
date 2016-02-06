namespace Phonebook.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Models;

    public class ListCommand : BaseCommand
    {
        public ListCommand(IPhonebookRepository phonebookRepository, string[] commandArguments) : base(phonebookRepository, commandArguments)
        {
        }

        public override string Execute()
        {
            StringBuilder commandResult = new StringBuilder();
            try
            {
                IEnumerable<PhoneEntry> phoneEntries = this.PhonebookRepository
                    .ListEntries(int.Parse(this.commandArguments[0]), int.Parse(this.commandArguments[1]));

                commandResult.Append(string.Join(Environment.NewLine, phoneEntries));
            }
            catch (ArgumentOutOfRangeException)
            {
                commandResult.Append("Invalid range");
            }

            return commandResult.ToString();
        }
    }
}