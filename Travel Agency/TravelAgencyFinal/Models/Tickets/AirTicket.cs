namespace TravelAgency.Models.Tickets
{
    using System;

    internal class AirTicket : Ticket
    {
        public AirTicket(
            string flightNumber,
            string departureTown,
            string arrivalTown,
            string airline,
            string dateAndTimeString,
            string priceString)
        {
            DateTime dateAndTime = ParseDateTime(dateAndTimeString);
            decimal price = decimal.Parse(priceString);

            this.FlightNumber = flightNumber;
            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.Company = airline;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber { get; set; }

        public override string TicketType
        {
            get
            {
                return "air";
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.TicketType + ";;" + this.FlightNumber;
            }
        }
    }
}