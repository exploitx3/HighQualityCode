namespace VehicleParkSystem.Models.Vehicles
{
    using System;
    using VehicleParkSystem.Utilities;

    public class Car : Vehicle
    {
        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, Constants.RegularCarRate, Constants.OvertimeCarRate, reservedHours)
        {
        }
    }
}
