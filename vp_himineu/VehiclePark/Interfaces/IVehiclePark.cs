namespace VehiclePark.Interfaces
{
    using System;
    using Models.Vehicles;

    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts a Car in the VehiclePark
        /// </summary>
        /// <param name="car">The car to be inserted</param>
        /// <param name="sector">The sector where the car will be parked</param>
        /// <param name="placeNumber">The place numbe in the sector where the car will be parked</param>
        /// <param name="startTime">The parking time</param>
        /// <returns>The result string after inserting the car in the VehiclePark.</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);
        /// <summary>
        /// Inserts a Motorbike in the VehiclePark
        /// </summary>
        /// <param name="motorbike">The motorbike to be inserted</param>
        /// <param name="sector">The sector where the motorbike will be parked</param>
        /// <param name="placeNumber">The place numbe in the sector where the motorbike will be parked</param>
        /// <param name="startTime">The parking time</param>
        /// <returns>The result string after inserting the motorbike in the VehiclePark.</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);
        /// <summary>
        /// Inserts a Truck in the VehiclePark
        /// </summary>
        /// <param name="truck">The truck to be inserted</param>
        /// <param name="sector">The sector where the truck will be parked</param>
        /// <param name="placeNumber">The place numbe in the sector where the truck will be parked</param>
        /// <param name="startTime">The parking time</param>
        /// <returns>The result string after inserting the truck in the VehiclePark.</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Exits a vehicle from the VehiclePark.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle to be removed.</param>
        /// <param name="endTime">The time when the vehicle has been removed</param>
        /// <param name="amountPaid">The amount paid for the stay</param>
        /// <returns>The result string after exitting the vehicle from the VehiclePark.</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// Prints the current status of the parking lot
        /// </summary>
        /// <returns>Returns the current status of the parking lot</returns>
        string GetStatus();

        /// <summary>
        /// Tries to find a vehicle with the specified license plate number in the parking lot.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <returns>Returns information about the searched vehicle or an error message</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Tries to find a vehicle with the specified Owner's name in the parking lot.
        /// </summary>
        /// <param name="owner">Owner's name</param>
        /// <returns>Returns information about the searched vehicle or an error message</returns>
        string FindVehiclesByOwner(string owner);
    }
}