namespace BuhtigIssueTracker.UserInterface
{
    using System;
    using Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params object[] arguments)
        {
            Console.WriteLine(format, arguments);
        }
    }
}