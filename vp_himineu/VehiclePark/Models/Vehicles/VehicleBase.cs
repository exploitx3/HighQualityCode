namespace VehiclePark.Models.Vehicles
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public abstract class VehicleBase : IVehicle
    {
        private int hoursStay;
        private string licensePlate;
        private decimal overtimeRate;
        private string personName;
        private decimal regularRate;

        protected VehicleBase(string licensePlate, string personName, int hoursStay)
        {
            this.LicensePlate = licensePlate;
            this.Owner = personName;
            this.ReservedHours = hoursStay;
            this.RegularRate = 2M;
            this.OvertimeRate = 3.5M;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.personName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.personName = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The regular rate must be non-negative.");
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The overtime rate must be non-negative.");
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.hoursStay;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.hoursStay = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}