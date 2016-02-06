namespace TravelAgency.Models.Tickets
{
    using System;
    using System.Globalization;

    internal abstract class Ticket : IComparable<Ticket>
    {
        public abstract string TicketType { get; }

        public string DepartureTown { get; set; }

        public string ArrivalTown { get; set; }

        public string Company { get; set; }

        public DateTime DateAndTime { get; set; }

        public decimal Price { get; set; }

        public virtual decimal SpecialPrice { get; set; }

        public abstract string TicketKey { get; }

        public string DepartureArrivalKey
        {
            get
            {
                return CreateDepartureArrivalKey(this.DepartureTown, this.ArrivalTown);
            }
        }

        public static string CreateDepartureArrivalKey(string departureTown, string arrivalTown)
        {
            return departureTown + "; " + arrivalTown;
        }

        public static DateTime ParseDateTime(string dt)
        {
            DateTime result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int result = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (result == 0)
            {
                result = this.TicketType.CompareTo(otherTicket.TicketType);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(otherTicket.Price);
            }

            return result;
        }

        public override string ToString()
        {
            string input = 
                "[" +
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + 
                "; " +
                this.TicketType + 
                "; " +
                string.Format("{0:f2}", this.Price) + 
                "]";

            return input;
        }
    }
}