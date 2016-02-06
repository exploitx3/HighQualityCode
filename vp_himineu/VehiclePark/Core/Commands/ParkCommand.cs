namespace VehiclePark.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Interfaces;
    using Models.Vehicles;

    public class ParkCommand : CommandBase
    {
        public ParkCommand(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var commandOutput = string.Empty;
            switch (this.Parameters["type"])
            {
                case "car":
                    commandOutput = this.VehiclePark.InsertCar(
                        new Car(
                            this.Parameters["licensePlate"],
                            this.Parameters["owner"],
                            int.Parse(this.Parameters["hours"])),
                        int.Parse(this.Parameters["sector"]),
                        int.Parse(this.Parameters["place"]),
                        DateTime.Parse(this.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                    break;
                case "motorbike":
                    commandOutput = this.VehiclePark.InsertMotorbike(
                        new Motorbike(
                            this.Parameters["licensePlate"],
                            this.Parameters["owner"],
                            int.Parse(this.Parameters["hours"])),
                        int.Parse(this.Parameters["sector"]),
                        int.Parse(this.Parameters["place"]),
                        DateTime.Parse(this.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                    break;
                case "truck":
                    commandOutput = this.VehiclePark.InsertTruck(
                        new Truck(
                            this.Parameters["licensePlate"],
                            this.Parameters["owner"],
                            int.Parse(this.Parameters["hours"])),
                        int.Parse(this.Parameters["sector"]),
                        int.Parse(this.Parameters["place"]),
                        DateTime.Parse(this.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                    break;
            }

            return commandOutput;
        }
    }
}