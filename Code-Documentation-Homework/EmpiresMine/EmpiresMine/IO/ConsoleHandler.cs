using System;

namespace EmpiresMine.IO
{
    public class ConsoleHandler : IInputOutputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}