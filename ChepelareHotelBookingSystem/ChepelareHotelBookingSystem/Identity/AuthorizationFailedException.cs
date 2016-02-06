namespace ChepelareHotelBookingSystem.Identity
{
    using System;
    using HotelBookingSystem.Models;
    using Models;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
