namespace VehiclePark.Models.Vehicles
{
    public class Motorbike : VehicleBase
    {
        public Motorbike(string licensePlate, string personName, int hoursStay)
            : base(licensePlate, personName, hoursStay)
        {
            this.RegularRate = 1.35M;
            this.OvertimeRate = 3M;
        }
    }
}