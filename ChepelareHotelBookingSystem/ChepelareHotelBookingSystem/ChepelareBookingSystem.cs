using System;

namespace ChepelareHotelBookingSystem
{
    using Interfaces;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var chepelareEngine = Activator.CreateInstance(typeof(Engine)) as IEngine;

            chepelareEngine.Run();
        }
    }
}
