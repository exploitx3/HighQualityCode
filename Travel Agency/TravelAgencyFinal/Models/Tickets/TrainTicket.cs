namespace TravelAgency.Models.Tickets
{
    using System;

    internal class TrainTicket : Ticket
    {
        public TrainTicket(string departureTown, string arrivalTown, string dateTimeString, string regularPriceString, string studentPriceString)
        {
            decimal price = decimal.Parse(regularPriceString);
            DateTime dateAndTime = ParseDateTime(dateTimeString);
            decimal studentPrice = decimal.Parse(studentPriceString);

            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.DateAndTime = dateAndTime;
            this.Price = price;
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string departureTown, string arrivalTown, string dateTimeString)
        {
            DateTime dateAndTime = ParseDateTime(dateTimeString);

            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.DateAndTime = dateAndTime;
        }

        public decimal StudentPrice { get; set; }

        public override string TicketType
        {
            get
            {
                return "train";
            }
        }

        public override string TicketKey
        {
            get
            {
                return this.TicketType + 
                       ";;" +
                       this.DepartureTown +
                       ";" +
                       this.ArrivalTown + 
                       ";" + 
                       this.DateAndTime +
                       ";";
            }
        }
    }
}