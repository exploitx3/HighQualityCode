namespace VehiclePark.Models.Vehicles
{
    public class Car : VehicleBase
    {
        public Car(string licensePlate, string personName, int hoursStay) : base(licensePlate, personName, hoursStay)
        {
            this.RegularRate = 2M;
            this.OvertimeRate = 3.5M;
        }
    }
}