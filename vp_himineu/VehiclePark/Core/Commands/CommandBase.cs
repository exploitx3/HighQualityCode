namespace VehiclePark.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommandBase : ICommand
    {
        protected readonly IVehiclePark VehiclePark;

        protected CommandBase(string name, IDictionary<string, string> parameters, IVehiclePark vehiclePark)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.VehiclePark = vehiclePark;
        }

        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public abstract object Execute();
    }
}