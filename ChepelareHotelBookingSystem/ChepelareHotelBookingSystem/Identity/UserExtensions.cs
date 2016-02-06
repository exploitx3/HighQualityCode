namespace ChepelareHotelBookingSystem.Identity
{
    using HotelBookingSystem.Models;
    using Models;

    public static class UserExtensions
    {
        public static bool IsInRole(this User user, Roles role)
        {
            return user.Role == role;
        }
    }
}
