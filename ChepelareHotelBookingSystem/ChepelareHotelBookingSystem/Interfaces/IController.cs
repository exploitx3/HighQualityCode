namespace ChepelareHotelBookingSystem.Interfaces
{
    using HotelBookingSystem.Models;
    using Models;

    public interface IController
    {
        bool HasCurrentUser { get; }

        IHotelBookingSystemData Data { get; set; }

        IView View(object model);

        User CurrentUser { get; set; }
    }
}