namespace VehiclePark.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class StatusCommand : CommandBase
    {
        public StatusCommand(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var commandOutput = this.VehiclePark.GetStatus();

            return commandOutput;
        }
    }
}