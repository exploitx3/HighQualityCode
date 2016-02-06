namespace ChepelareHotelBookingSystem.Interfaces
{
    using HotelBookingSystem.Models;
    using Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}