namespace VehiclePark.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class FindVehicleCommand : CommandBase
    {
        public FindVehicleCommand(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var commandOutput = this.VehiclePark.FindVehicle(this.Parameters["licensePlate"]);

            return commandOutput;
        }
    }
}