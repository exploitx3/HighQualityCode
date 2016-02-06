namespace TravelAgency.Models.Tickets
{
    using System;

    internal class BusTicket : Ticket
    {
        public BusTicket(string departureTown, string arrivalTown, string travelCompany, string dateAndtime, string priceString)
        {
            DateTime dateAndTime = ParseDateTime(dateAndtime);
            decimal price = decimal.Parse(priceString);

            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.Company = travelCompany;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public BusTicket(string departureTown, string arrivalTown, string travelCompany, string dateAndtime)
        {
            DateTime dateAndTime = ParseDateTime(dateAndtime);

            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.Company = travelCompany;
            this.DateAndTime = dateAndTime;
        }

        public override string TicketType
        {
            get
            {
                return "bus";
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.TicketType + 
                       ";;" + 
                       this.DepartureTown + 
                       ";" + this.ArrivalTown + 
                       ";" + 
                       this.Company + 
                       this.DateAndTime + 
                       ";";
            }
        }
    }
}