namespace VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Core.Commands;
    using Interfaces;

    public class CommandExecuter : ICommandExecutor
    {
        public CommandExecuter()
        {
            this.VehiclePark = null;
        }

        private IVehiclePark VehiclePark { get; set; }

        public string ExecuteCommand(string commandArguments)
        {
            var commandName = commandArguments.Substring(0, commandArguments.IndexOf(' '));

            var commandParameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(
                    commandArguments.Substring(commandArguments.IndexOf(' ') + 1));

            if (commandName != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            ICommand command = null;
            switch (commandName)
            {
                case "SetupPark":
                    command = new SetupParkCommand(commandName, commandParameters, this.VehiclePark);
                    break;
                case "Park":
                    command = new ParkCommand(commandName, commandParameters, this.VehiclePark);
                    break;
                case "Exit":
                    command = new ExitCommand(commandName, commandParameters, this.VehiclePark);
                    break;
                case "Status":
                    command = new StatusCommand(commandName, commandParameters, this.VehiclePark);
                    break;
                case "FindVehicle":
                    command = new FindVehicleCommand(commandName, commandParameters, this.VehiclePark);
                    break;
                case "VehiclesByOwner":
                    command = new VehiclesByOwner(commandName, commandParameters, this.VehiclePark);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command.");
            }

            var commandOutput = string.Empty;
            if (commandName == "SetupPark")
            {
                this.VehiclePark = command.Execute() as IVehiclePark;
                commandOutput = "Vehicle park created";
            }
            else
            {
                commandOutput = command.Execute() as string;
            }

            return commandOutput;
        }
    }
}