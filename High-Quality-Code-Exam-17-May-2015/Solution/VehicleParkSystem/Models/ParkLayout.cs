namespace VehicleParkSystem.Models
{
    using System;

    public class ParkLayout
    {
        private int numberOfSectors;
        private int placesPerSector;

        public ParkLayout(int numberOfSectors, int placesPerSector)
        {
            this.NumberOfSectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int NumberOfSectors
        {
            get
            {
                return this.numberOfSectors;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}
