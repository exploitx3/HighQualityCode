namespace Phonebook.Interfaces
{
    public interface IInputOutputHandler
    {
        string ReadLine();

        void WriteLine(string format, params object[] formatArguments);

        void Write(string format, params object[] formatArguments);
    }
}