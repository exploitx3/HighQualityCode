namespace TheatreSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Interfaces;
    using Models;

    internal class TheatreEngine : IEngine
    {
        private readonly ICommandExecutor commandExecutor;

        public TheatreEngine(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public virtual void Run()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(inputLine))
                {
                    this.commandExecutor.ExecuteCommand(inputLine);
                }
            }
        }
    }
}