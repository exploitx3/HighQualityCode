namespace VehicleParkSystem.Models.Vehicles
{
    using System;
    using VehicleParkSystem.Utilities;

    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, Constants.RegularMotorbikeRate, Constants.OvertimeMotorbikeRate, reservedHours)
        {
        }
    }
}
