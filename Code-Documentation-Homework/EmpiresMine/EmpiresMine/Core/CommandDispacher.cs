using System;
using System.CodeDom;
using EmpiresMine.Core.Commands;
using EmpiresMine.Interfaces;
using EmpiresMine.Models.Interfaces;

namespace EmpiresMine.Core
{
    public class CommandDispacher : ICommandDispacher
    {
        private IDatabase database;
        public CommandDispacher(IDatabase database)
        {
            this.database = database;
        }
        public void DispatchCommand(string[] parameters)
        {
            string commandName = parameters[0];
            switch (commandName)
            {
                case "build":
                    string buildingType = parameters[1];
                    ICommand buildCommand = new BuildCommand(commandName, buildingType, database);
                    CommandExecutor.ExecuteCommand(buildCommand, database);
                    break;

                case "skip":
                    CommandExecutor.TurnsIncrement(this.database);
                    break;

                case "empire-status":
                    ICommand empireStatusCommand = new EmpireStatusCommand(commandName, database);
                    CommandExecutor.ExecuteCommand(empireStatusCommand, database);
                    break;
                default:
                    throw new ArgumentException("Invalid command name");
            }

           
        }
    }
}