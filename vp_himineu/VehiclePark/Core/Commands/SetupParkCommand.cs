namespace VehiclePark.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Models.Layouts;

    public class SetupParkCommand : CommandBase
    {
        public SetupParkCommand(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
            : base(name, parameters, vehiclePark)
        {
        }

        public override object Execute()
        {
            var newVehiclePark =
                new VehiclePark(
                    new Layout(int.Parse(this.Parameters["sectors"]), int.Parse(this.Parameters["placesPerSector"])),
                    new Database(int.Parse(this.Parameters["sectors"])));

            return newVehiclePark;
        }
    }
}