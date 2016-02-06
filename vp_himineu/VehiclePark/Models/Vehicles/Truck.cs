namespace VehiclePark.Models.Vehicles
{
    public class Truck : VehicleBase
    {
        public Truck(string licensePlate, string personName, int hoursStay) : base(licensePlate, personName, hoursStay)
        {
            this.RegularRate = 4.75M;
            this.OvertimeRate = 6.2M;
        }
    }
}