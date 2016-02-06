namespace VehiclePark.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Interfaces;

    public class ExitCommand : CommandBase
    {
        public ExitCommand(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var commandOutput = this.VehiclePark.ExitVehicle(
                this.Parameters["licensePlate"],
                DateTime.Parse(this.Parameters["time"], null, DateTimeStyles.RoundtripKind),
                decimal.Parse(this.Parameters["paid"]));

            return commandOutput;
        }
    }
}