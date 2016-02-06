namespace VehicleParkSystem
{
    using System;
    using System.Globalization;
    using System.Threading;
    using VehicleParkSystem.Execution;
    using VehicleParkSystem.UserInterface;

    public class VehicleParkSystemProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new VehicleParkEngine();
            engine.Run();
        }
    }
}