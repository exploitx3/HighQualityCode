namespace VehiclePark.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Interfaces;
    using Layouts;
    using Vehicles;

    public class VehiclePark : IVehiclePark
    {
        private readonly IDatabase database;
        private readonly ILayout layout;

        public VehiclePark(ILayout layout, IDatabase database)
        {
            this.layout = layout;
            this.database = database;
        }

        public string InsertCar(Car car, int sector, int place, DateTime carReservedHours)
        {
            if (sector > this.layout.Sectors || sector < 0)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector || place < 0)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.database.CarsByCarParkingPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.database.VehiclesByPlates.ContainsKey(car.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", car.LicensePlate);
            }

            this.database.CarParkingPlaceByCar[car] = string.Format("({0},{1})", sector, place);

            this.database.CarsByCarParkingPlace[string.Format("({0},{1})", sector, place)] = car;

            this.database.VehiclesByPlates[car.LicensePlate] = car;

            this.database.VehicleArrivalTime[car] = carReservedHours;

            this.database.OwnerNames[car.Owner].Add(car);

            this.database.SectorsCount[sector - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, sector, place);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime bikeReservedHoures)
        {
            if (sector > this.layout.Sectors || sector < 0)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector || place < 0)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.database.CarsByCarParkingPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.database.VehiclesByPlates.ContainsKey(motorbike.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    motorbike.LicensePlate);
            }

            this.database.CarParkingPlaceByCar[motorbike] = string.Format("({0},{1})", sector, place);

            this.database.CarsByCarParkingPlace[string.Format("({0},{1})", sector, place)] = motorbike;

            this.database.VehiclesByPlates[motorbike.LicensePlate] = motorbike;

            this.database.VehicleArrivalTime[motorbike] = bikeReservedHoures;

            this.database.OwnerNames[motorbike.Owner].Add(motorbike);

            this.database.SectorsCount[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", motorbike.GetType().Name, sector, place);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime truckReservedHours)
        {
            if (sector > this.layout.Sectors || sector < 0)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.PlacesPerSector || place < 0)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.database.CarsByCarParkingPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.database.VehiclesByPlates.ContainsKey(truck.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    truck.LicensePlate);
            }

            this.database.CarParkingPlaceByCar[truck] = string.Format("({0},{1})", sector, place);

            this.database.CarsByCarParkingPlace[string.Format("({0},{1})", sector, place)] = truck;

            this.database.VehiclesByPlates[truck.LicensePlate] = truck;

            this.database.VehicleArrivalTime[truck] = truckReservedHours;

            this.database.OwnerNames[truck.Owner].Add(truck);

            this.database.SectorsCount[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = this.database.VehiclesByPlates.ContainsKey(licensePlate)
                ? this.database.VehiclesByPlates[licensePlate]
                : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var start = this.database.VehicleArrivalTime[vehicle];
            var totalHoursStayed = (int)Math.Round((endTime - start).TotalHours);
            var overTimeRate = totalHoursStayed > vehicle.ReservedHours
                ? (totalHoursStayed - vehicle.ReservedHours) * vehicle.OvertimeRate
                : 0;

            var totalCharged = (vehicle.ReservedHours * vehicle.RegularRate) + overTimeRate;
            var ticket = new StringBuilder();
            ticket.AppendLine(
                new string('*', 20))
                .AppendFormat("{0}", vehicle)
                .AppendLine()
                .AppendFormat("at place {0}", this.database.CarParkingPlaceByCar[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overTimeRate)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", totalCharged)
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", money)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", money - totalCharged)
                .AppendLine()
                .Append(new string('*', 20));

            var sector = int.Parse(
                this.database.CarParkingPlaceByCar[vehicle].Split(
                    new[] { "(", ",", ")" },
                    StringSplitOptions.RemoveEmptyEntries)[0]);

            this.database.CarsByCarParkingPlace.Remove(this.database.CarParkingPlaceByCar[vehicle]);

            this.database.CarParkingPlaceByCar.Remove(vehicle);

            this.database.VehiclesByPlates.Remove(vehicle.LicensePlate);

            this.database.VehicleArrivalTime.Remove(vehicle);

            this.database.OwnerNames.Remove(vehicle.Owner, vehicle);

            this.database.SectorsCount[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.database
                .SectorsCount
                .Select((placesCount, sectorIndex) => string.Format(
                    "Sector {0}: {1} / {2} ({3}% full)",
                    sectorIndex + 1,
                    placesCount,
                    this.layout.PlacesPerSector,
                    Math.Round((double)placesCount / this.layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.database.VehiclesByPlates.ContainsKey(licensePlate)
                ? this.database.VehiclesByPlates[licensePlate]
                : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.database.OwnerNames.ContainsKey(owner))
            {
                return string.Format("No vehicles by {0}", owner);
            }

            ////PERFORMANCE : Not using Owner's names for searching the owner's cars.FIXED
            var found = this.database
                .OwnerNames[owner].ToList()
                .OrderBy(v => this.database.VehicleArrivalTime[v])
                .ThenBy(v => v.LicensePlate);

            return string.Join(Environment.NewLine, this.Input(found));
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(
                Environment.NewLine,
                vehicles.Select(
                    vehicle =>
                        string.Format(
                            "{0}{1}Parked at {2}",
                            vehicle.ToString(),
                            Environment.NewLine,
                            this.database.CarParkingPlaceByCar[vehicle])));
        }
    }
}