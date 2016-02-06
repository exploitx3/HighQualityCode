namespace Phonebook.Core.IO
{
    using System;
    using Interfaces;
    public class InpuOutputHandler : IInputOutputHandler
    {
        public string ReadLine()
        {
            var result = Console.ReadLine();

            return result;
        }

        public void WriteLine(string format, params object[] formatArguments)
        {
            Console.WriteLine(format, formatArguments);
        }

        public void Write(string format, params object[] formatArguments)
        {
            Console.Write(format, formatArguments);
        }
    }
}