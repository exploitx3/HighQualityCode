namespace VehiclePark.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class VehiclesByOwner : CommandBase
    {
        public VehiclesByOwner(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var commandOutput = this.VehiclePark.FindVehiclesByOwner(this.Parameters["owner"]);

            return commandOutput;
        }
    }
}