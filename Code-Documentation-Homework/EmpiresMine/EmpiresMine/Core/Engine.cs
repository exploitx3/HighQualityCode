using System;
using EmpiresMine.Interfaces;

namespace EmpiresMine.Core
{
    public class Engine : IEngine
    {
        private IDatabase database;
        private ICommandDispacher commandDispacher;

        public Engine(IDatabase database, ICommandDispacher commandDispacher)
        {
            this.Database = database;
            this.CommandDispacher = commandDispacher;
        }

        public IDatabase Database
        {
            get { return this.database; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Database cannot be null");
                }
                this.database = value;
            }
        }

        public ICommandDispacher CommandDispacher
        {
            get { return this.commandDispacher; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Command-Dispacher cannot be null");
                }
                this.commandDispacher = value;
            }
        }
        public void Run()
        {
            string inputCommandString;
            while ((inputCommandString = Console.ReadLine()) != "armistice")
            {
                string[] commandParams = inputCommandString.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                this.CommandDispacher.DispatchCommand(commandParams);
            }
        }
    }
}