namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using ChepelareHotelBookingSystem.Interfaces;
    using ChepelareHotelBookingSystem.Models;
    using ChepelareHotelBookingSystem.Utilities;

    public class User : IDbEntity
    {
        private string passwordHash;
        private string username;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The username must be at least 5 symbols long.");
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get { return this.passwordHash; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException("The password must be at least 6 symbols long.");
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        public int Id { get; set; }
    }
}
