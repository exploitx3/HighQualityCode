namespace VehicleParkSystem.Interfaces
{
    using System;
    using VehicleParkSystem.Models.Vehicles;

    /// <summary>
    /// Provides the basic operations required to run a vehicle park.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts a car in the vehicle park.
        /// </summary>
        /// <param name="car">The car to insert in the park</param>
        /// <param name="sector">The sector where the car should be parked</param>
        /// <param name="placeNumber">The number of the place within the sector where the car should be parked</param>
        /// <param name="startTime">The time of parking. Used to calculate the price for the parking ticket</param>
        /// <returns>Returns a success message if the car has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.
        /// </returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Inserts a motorbike in the vehicle park.
        /// </summary>
        /// <param name="motorbike">The motorbike to insert in the park</param>
        /// <param name="sector">The sector where the motorbike should be parked</param>
        /// <param name="placeNumber">The number of the place within the sector where the motorbike should be parked</param>
        /// <param name="startTime">The time of parking. Used to calculate the price for the parking ticket</param>
        /// <returns>Returns a success message if the motorbike has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.
        /// </returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Inserts a truck in the vehicle park.
        /// </summary>
        /// <param name="truck">The truck to insert in the park</param>
        /// <param name="sector">The sector where the truck should be parked</param>
        /// <param name="placeNumber">The number of the place within the sector where the truck should be parked</param>
        /// <param name="startTime">The time of parking. Used to calculate the price for the parking ticket</param>
        /// <returns>Returns a success message if the truck has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.
        /// </returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Performs all operations required when a vehicle leaves the park. Removes the vehicle from the park and prints a parking ticket for the owner.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <param name="endTime">The time of leaving. Used to calculate the price for the parking ticket</param>
        /// <param name="amountPaid">The amount paid by the customer</param>
        /// <returns>Returns the issued parking ticket in a ready to print form. If there is no vehicle with the specified license plate number
        /// in the park, returns an error message.
        /// </returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// Displays the current status of the vehicle park - how many parking slots are full in each of the parking sectors
        /// </summary>
        /// <returns>Returns a message displaying the number of free spaces (and the full percentage) in the park.</returns>
        string GetStatus();

        /// <summary>
        /// Finds the vehicle with the specified license plate number in the vehicle park.
        /// </summary>
        /// <param name="licensePlate">The license plate number of the vehicle to find</param>
        /// <returns>Returns information about the vehicle and its parking place. If there is no vehicle with the specified license plate
        /// in the park, returns an error message.
        /// </returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Finds all vehicles in the park which belong to the specified owner.
        /// </summary>
        /// <param name="owner">The owner of the vehicles to find</param>
        /// <returns>Returns information about each vehicle by the owner, ordered by arrival time and by license plate number. If there
        /// are no vehicles by the owner, returns an error message.
        /// </returns>
        string FindVehiclesByOwner(string owner);
    }
}
