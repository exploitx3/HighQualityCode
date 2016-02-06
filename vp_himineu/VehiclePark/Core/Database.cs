namespace VehiclePark.Core
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class Database : IDatabase
    {
        public Database(int numberOfSectors)
        {
            this.CarParkingPlaceByCar = new Dictionary<IVehicle, string>();
            this.CarsByCarParkingPlace = new Dictionary<string, IVehicle>();
            this.VehiclesByPlates = new Dictionary<string, IVehicle>();
            this.VehicleArrivalTime = new Dictionary<IVehicle, DateTime>();
            this.OwnerNames = new MultiDictionary<string, IVehicle>(false);
            this.SectorsCount = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> CarParkingPlaceByCar { get; set; }

        public Dictionary<string, IVehicle> CarsByCarParkingPlace { get; set; }

        public Dictionary<string, IVehicle> VehiclesByPlates { get; set; }

        public Dictionary<IVehicle, DateTime> VehicleArrivalTime { get; set; }

        public MultiDictionary<string, IVehicle> OwnerNames { get; set; }

        public int[] SectorsCount { get; set; }
    }
}