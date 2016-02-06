namespace VehiclePark.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IDatabase
    {
        Dictionary<IVehicle, string> CarParkingPlaceByCar { get; set; }

        Dictionary<string, IVehicle> CarsByCarParkingPlace { get; set; }

        Dictionary<string, IVehicle> VehiclesByPlates { get; set; }

        Dictionary<IVehicle, DateTime> VehicleArrivalTime { get; set; }

        MultiDictionary<string, IVehicle> OwnerNames { get; set; }

        int[] SectorsCount { get; set; }
    }
}