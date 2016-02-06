namespace VehiclePark.Models.Layouts
{
    using System;
    using Interfaces;

    public class Layout : ILayout
    {
        private int placesPerSector;
        private int sectors;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }
    }
}