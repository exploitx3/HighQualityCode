namespace Phonebook
{
    using Core;
    using Core.IO;
    using Interfaces;
    using Models;

    public class PhoneBookMain
    {

        private static void Main()
        {
            IInputOutputHandler inputOutputHandler = new InpuOutputHandler();
            IPhonebookRepository phonebookRepository = new PhoneBookOrganized();
            ICommandExecutor commandExecutor = new CommandExecutor(phonebookRepository);

            IEngine engine = new Engine(commandExecutor, inputOutputHandler);
            engine.Run();
        }
    }
}