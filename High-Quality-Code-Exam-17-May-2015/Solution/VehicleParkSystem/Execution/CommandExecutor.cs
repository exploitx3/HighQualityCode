namespace VehicleParkSystem.Execution
{
    using System;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;

    public class CommandExecutor
    {
        public VehiclePark VehiclePark { get; private set; }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult = string.Empty;
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                commandResult = "The vehicle park has not been set up";
                return commandResult;
            }

            switch (command.Name)
            {
                case "SetupPark":
                    this.VehiclePark = new VehiclePark(
                        int.Parse(command.Parameters["sectors"]),
                        int.Parse(command.Parameters["placesPerSector"]));
                    commandResult = "Vehicle park created";
                    break;
                case "Park":
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            commandResult = this.ExecuteParkCarCommand(command);
                            break;
                        case "motorbike":
                            commandResult = this.ExecuteParkMotorbikeCommand(command);
                            break;
                        case "truck":
                            commandResult = this.ExecuteParkTruckCommand(command);
                            break;
                        default:
                            break;
                    }

                    break;
                case "Exit":
                    commandResult = this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"],
                        DateTimeUtilities.ParseISODateTime(command.Parameters["time"]),
                        decimal.Parse(command.Parameters["paid"]));
                    break;
                case "Status":
                    commandResult = this.VehiclePark.GetStatus();
                    break;
                case "FindVehicle":
                    commandResult = this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                    break;
                case "VehiclesByOwner":
                    commandResult = this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command.");
            }

            return commandResult;
        }

        private string ExecuteParkCarCommand(ICommand command)
        {
            var car = new Car(command.Parameters["licensePlate"], command.Parameters["owner"], int.Parse(command.Parameters["hours"]));
            string commandResult = this.VehiclePark.InsertCar(
                car,
                int.Parse(command.Parameters["sector"]),
                int.Parse(command.Parameters["place"]),
                DateTimeUtilities.ParseISODateTime(command.Parameters["time"]));
            return commandResult;
        }

        private string ExecuteParkMotorbikeCommand(ICommand command)
        {
            var motorbike = new Motorbike(command.Parameters["licensePlate"], command.Parameters["owner"], int.Parse(command.Parameters["hours"]));
            string commandResult = this.VehiclePark.InsertMotorbike(
                motorbike,
                int.Parse(command.Parameters["sector"]),
                int.Parse(command.Parameters["place"]),
                DateTimeUtilities.ParseISODateTime(command.Parameters["time"]));
            return commandResult;
        }

        private string ExecuteParkTruckCommand(ICommand command)
        {
            var truck = new Truck(command.Parameters["licensePlate"], command.Parameters["owner"], int.Parse(command.Parameters["hours"]));
            string commandResult = this.VehiclePark.InsertTruck(
                truck,
                int.Parse(command.Parameters["sector"]),
                int.Parse(command.Parameters["place"]),
                DateTimeUtilities.ParseISODateTime(command.Parameters["time"]));
            return commandResult;
        }
    }
}
