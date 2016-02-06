using System;
using System.Globalization;
using System.Threading;

namespace TravelAgency
{
    using Core;

    internal class TravelAgencyMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            TicketCatalog catalog = new TicketCatalog();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                string commandResult = catalog.ExecuteCommand(line);
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}