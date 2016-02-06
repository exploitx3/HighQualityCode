namespace VehiclePark.IO
{
    using System;
    using Interfaces;
    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params object[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(format);
            }
            else
            {
                Console.WriteLine(string.Format(format, args));
            }
        }
    }
}