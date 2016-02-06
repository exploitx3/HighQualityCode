namespace TheatreSystem.Core.Commands
{
    using System;
    using Interfaces;
    using Models;

    public abstract class BaseCommand : ICommand
    {
        private string[] commandArgs;
        private IPerformanceDatabase performanceDatabase;
        
        protected BaseCommand(string[] args, IPerformanceDatabase performanceDatabase)
        {
            this.CommandArgs = args;
            this.PerformanceDatabase = performanceDatabase;
        }

        protected string[] CommandArgs
        {
            get
            {
                return this.commandArgs;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "CommandArguments should be initialized.");
                }

                this.commandArgs = value;
            }
        }

        protected IPerformanceDatabase PerformanceDatabase
        {
            get
            {
                return this.performanceDatabase;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "performanceDatabase must be inicialized.");
                }

                this.performanceDatabase = value;
            }
        }

        public abstract string Execute();
    }
}