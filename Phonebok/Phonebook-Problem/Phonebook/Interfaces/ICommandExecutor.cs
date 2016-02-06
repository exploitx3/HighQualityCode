namespace Phonebook.Interfaces
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(string commandName, string[] commandArguments);
    }
}