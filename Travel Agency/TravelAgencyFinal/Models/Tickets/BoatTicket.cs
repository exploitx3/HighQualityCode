namespace TravelAgency.Models.Tickets
{
    using System;

    internal class BoatTicket : Ticket
    {
        public BoatTicket(string departureTown, string arrivalTown, string boatCompany, string dt, string pp)
        {
            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.Company = boatCompany;

            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public override string TicketType
        {
            get
            {
                return "boat";
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.TicketType + ";;" + this.DepartureTown + ";" + this.ArrivalTown + ";" +
                       this.Company + this.DateAndTime + ";";
            }
        }
    }
}