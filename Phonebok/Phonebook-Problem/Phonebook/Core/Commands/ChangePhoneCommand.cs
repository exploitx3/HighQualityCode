namespace Phonebook.Core.Commands
{
    using Interfaces;
    using Utilities;

    public class ChangePhoneCommand : BaseCommand
    {
        public ChangePhoneCommand(IPhonebookRepository phonebookRepository, string[] commandArguments) : base(phonebookRepository, commandArguments)
        {
        }

        public override string Execute()
        {
            string result =
                ("" + this.PhonebookRepository.ChangePhone(
                    PhoneUtilities.ConvertPhone(this.commandArguments[0]),
                    PhoneUtilities.ConvertPhone(this.commandArguments[1]))
                + " numbers changed");

            return result;
        }
    }
}