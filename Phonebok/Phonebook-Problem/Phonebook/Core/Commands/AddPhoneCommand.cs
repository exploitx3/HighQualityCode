namespace Phonebook.Core.Commands
{
    using System.Linq;
    using Interfaces;
    using Utilities;

    public class AddPhoneCommand : BaseCommand
    {
        public AddPhoneCommand(IPhonebookRepository phonebookRepository, string[] commandArguments)
            : base(phonebookRepository, commandArguments)
        {
        }

        public override string Execute()
        {
            string personName = this.commandArguments[0];
            var phonesList = this.commandArguments.Skip(1).ToList();
            for (int i = 0; i < phonesList.Count; i++)
            {
                phonesList[i] = PhoneUtilities.ConvertPhone(phonesList[i]);
            }
            bool isFirstPhoneEntryPerPerson = this.PhonebookRepository.AddPhone(personName, phonesList);

            string commandResult = null;
            if (isFirstPhoneEntryPerPerson)
            {
                commandResult = "Phone entry created";
            }
            else
            {
                commandResult = "Phone entry merged";
            }

            return commandResult;
        }

     
    }
}