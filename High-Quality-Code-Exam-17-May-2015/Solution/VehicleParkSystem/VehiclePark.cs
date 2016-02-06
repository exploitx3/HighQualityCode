namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;
    using Wintellect.PowerCollections;

    public class VehiclePark : IVehiclePark
    {
        private ParkLayout layout;
        private VehicleParkData data;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new ParkLayout(numberOfSectors, placesPerSector);
            this.data = new VehicleParkData(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(car, sector, placeNumber, startTime);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(motorbike, sector, placeNumber, startTime);
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(truck, sector, placeNumber, startTime);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            string commandResult = null;

            var vehicle = this.TryGetVehicleByLicensePlate(licensePlate);
            if (vehicle == null)
            {
                commandResult = string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
                return commandResult;
            }

            var startTime = this.data.VehiclesByStartTime[vehicle];
            int hoursInPark = (int)Math.Round((endTime - startTime).TotalHours);
            commandResult = this.PrintTicket(vehicle, hoursInPark, amountPaid);

            this.data.RemoveVehicleFromDatabase(vehicle);

            return commandResult;
        }

        public string GetStatus()
        {
            var places = this.data.SpacesCount
                .Select((spaces, index) => string.Format(
                    "Sector {0}: {1} / {2} ({3}% full)",
                    index + 1,
                    spaces, 
                    this.layout.PlacesPerSector,
                    Math.Round((double)spaces / this.layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            string commandResult = null;

            var vehicle = this.TryGetVehicleByLicensePlate(licensePlate);
            if (vehicle == null)
            {
                commandResult = string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
                return commandResult;
            }

            commandResult = this.FormatVehiclesForPrinting(new[] { vehicle });

            return commandResult;
        }

        public string FindVehiclesByOwner(string owner)
        {
            string commandResult = null;

            if (!this.data.VehiclesByOwner.ContainsKey(owner))
            {
                commandResult = string.Format("No vehicles by {0}", owner);
            }
            else
            {
                var foundVehicles = this.data.VehiclesByOwner[owner]
                    .OrderBy(v => this.data.VehiclesByStartTime[v])
                    .ThenBy(v => v.LicensePlate);
                commandResult = string.Join(Environment.NewLine, this.FormatVehiclesForPrinting(foundVehicles));
            }

            return commandResult;
        }

        private string GenerateParkPlaceKey(int sector, int placeNumber)
        {
            return string.Format("({0},{1})", sector, placeNumber);
        }

        private IVehicle TryGetVehicleByLicensePlate(string licensePlate)
        {
            if (this.data.VehiclesByLicensePlate.ContainsKey(licensePlate))
            {
                return this.data.VehiclesByLicensePlate[licensePlate];
            }

            return null;
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        {
            string commandResult = null;

            if (sector > this.layout.NumberOfSectors)
            {
                commandResult = string.Format("There is no sector {0} in the park", sector);
                return commandResult;
            }

            if (placeNumber > this.layout.PlacesPerSector)
            {
                commandResult = string.Format("There is no place {0} in sector {1}", placeNumber, sector);
                return commandResult;
            }

            string place = this.GenerateParkPlaceKey(sector, placeNumber);
            if (this.data.ParkPlaces.ContainsKey(place))
            {
                commandResult = string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
                return commandResult;
            }

            if (this.data.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                commandResult = string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
                return commandResult;
            }

            this.data.InsertVehicleInDatabase(vehicle, sector, startTime, place);

            commandResult = string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, placeNumber);
            return commandResult;
        }

        private string PrintTicket(IVehicle vehicle, int hours, decimal amountPaid)
        {
            var ticket = new StringBuilder();
            decimal rate = vehicle.ReservedHours * vehicle.RegularRate;
            decimal overtimeRate = hours > vehicle.ReservedHours ? (hours - vehicle.ReservedHours) * vehicle.OvertimeRate : 0;

            string ticketSeparator = new string('*', 20);
            string innerSeparator = new string('-', 20);
            ticket.AppendLine(ticketSeparator)
                .AppendFormat("{0}", vehicle.ToString()).AppendLine()
                .AppendFormat("at place {0}", this.data.VehiclesInParkPlaces[vehicle]).AppendLine()
                .AppendFormat("Rate: ${0:F2}", rate).AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overtimeRate).AppendLine()
                .AppendLine(innerSeparator)
                .AppendFormat("Total: ${0:F2}", rate + overtimeRate).AppendLine()
                .AppendFormat("Paid: ${0:F2}", amountPaid).AppendLine()
                .AppendFormat("Change: ${0:F2}", amountPaid - (rate + overtimeRate)).AppendLine()
                .Append(ticketSeparator);
            return ticket.ToString();
        }

        private string FormatVehiclesForPrinting(IEnumerable<IVehicle> vehicles)
        {
            var vehiclesAsStrings = vehicles
                .Select(vehicle => string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.data.VehiclesInParkPlaces[vehicle]));
            return string.Join(Environment.NewLine, vehiclesAsStrings);
        }
    }
}