namespace ChepelareHotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using HotelBookingSystem.Models;
    using Interfaces;

    public class Venue : IDbEntity
    {
        private string address;

        private string name;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new List<Room>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The venue name must be at least 3 symbols long.");
                }

                this.name = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The venue address must be at least 3 symbols long.");
                }
                this.address = value;
            }
        }

        public string Description { get; set; }

        public User Owner { get; set; }

        public ICollection<Room> Rooms { get; private set; }

        public int Id { get; set; }
    }
}
