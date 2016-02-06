namespace VehicleParkSystem.Models.Vehicles
{
    using System;
using VehicleParkSystem.Utilities;

    public class Truck : Vehicle
    {
        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, Constants.RegularTruckRate, Constants.OvertimeTruckRate, reservedHours)
        {
        }
    }
}
