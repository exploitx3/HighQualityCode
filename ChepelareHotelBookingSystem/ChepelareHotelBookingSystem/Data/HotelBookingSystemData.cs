namespace ChepelareHotelBookingSystem.Data
{
    using Interfaces;
    using Models;

    public class HotelBookingSystemData : IHotelBookingSystemData
    {
        public HotelBookingSystemData()
        {
            this.RepositoryWithUsers = new UserRepository();
            this.RepositoryWithVenues = new Repository<Venue>();
            this.RepositoryWithRooms = new Repository<Room>();
            this.RepositoryWithBookings = new Repository<Booking>();
        }

        public HotelBookingSystemData(IRepository<Venue> repositoryWithVenues, IRepository<Room> repositoryWithRooms)
        {
            this.RepositoryWithUsers = new UserRepository();
            this.RepositoryWithVenues = repositoryWithVenues;
            this.RepositoryWithRooms = repositoryWithRooms;
            this.RepositoryWithBookings = new Repository<Booking>();
        }

        public IUserRepository RepositoryWithUsers { get; }

        public IRepository<Venue> RepositoryWithVenues { get; set; }

        public IRepository<Room> RepositoryWithRooms { get; set; }

        public IRepository<Booking> RepositoryWithBookings { get; set; }
    }
}
