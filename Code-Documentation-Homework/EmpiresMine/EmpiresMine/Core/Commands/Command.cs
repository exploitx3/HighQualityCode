using System;
using EmpiresMine.Interfaces;

namespace EmpiresMine.Core.Commands
{
    public abstract class Command : ICommand
    {
        private IDatabase database;

        public Command(string name, IDatabase database)
        {
            this.Name = name;
            this.Database = database;
        }
        public string Name { get; }

        protected IDatabase Database
        {
            get { return this.database; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Database cannot be null");
                }
                this.database = value;
            }
        }

        public abstract void Execute();
    }
}