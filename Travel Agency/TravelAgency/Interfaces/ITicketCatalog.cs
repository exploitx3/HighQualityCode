namespace TravelAgency.Interfaces
{
    using System;
    using Enums;
    /// <summary>
    /// An Interface declaring methods for working with the catalog(adding, finding tickets)
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds an Air Ticket
        /// </summary>
        /// <param name="flightNumber">The flight number</param>
        /// <param name="departureTown">The departure town.</param>
        /// <param name="arrivalTown">The arrival town.</param>
        /// <param name="airline">Airline name</param>
        /// <param name="dateTime">The date and time of departure</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Successful message if the ticket was added or an error message otherwise</returns>
        string AddAirTicket(string flightNumber, string departureTown, string arrivalTown, string airline, DateTime dateTime, decimal price);
        /// <summary>
        /// Deletes an Air Ticket from the catalog
        /// </summary>
        /// <param name="flightNumber">The flight number of the ticket to be deleted</param>
        /// <returns>Successful message if the ticket was deleted or an error message otherwise</returns>
        string DeleteAirTicket(string flightNumber);
        /// <summary>
        /// Adds a Train Ticket
        /// </summary>
        /// <param name="departureTown">The departure town.</param>
        /// <param name="arrivalTown">The arrival town.</param>
        /// <param name="dateTime">The date and time of departure</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Successful message if the ticket was added or an error message otherwise</returns>
        string AddTrainTicket(string departureTown, string arrivalTown, DateTime dateTime, decimal price, decimal studentPrice);
        /// <summary>
        /// Deletes a Train Ticket from the catalog
        /// </summary>
        /// <param name="departureTown">The departure town.</param>
        /// <param name="arrivalTown">The arrival town.</param>
        /// <param name="dateTime">The date and time of the departure</param>
        /// <returns>Successful message if the ticket was deleted or an error message otherwise.</returns>
        string DeleteTrainTicket(string departureTown, string arrivalTown, DateTime dateTime);
        /// <summary>
        /// Adds a Bus Ticket
        /// </summary>
        /// <param name="departureTown">The departure town.</param>
        /// <param name="arrivalTown">The arrival town.</param>
        /// <param name="travelCompany">The travel company</param>
        /// <param name="dateTime">The date and time of departure</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Successful message if the ticket was added or an error message otherwise</returns>
        string AddBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Deletes a Bus Ticket from the Catalog
        /// </summary>
        /// <param name="departureTown">The departure town.</param>
        /// <param name="arrivalTown">The arrival town.</param>
        /// <param name="travelCompany">The travel company</param>
        /// <param name="dateTime">The date and time of the departure</param>
        /// <returns>Successful message if the ticket was deleted or an error message otherwise.</returns>
        string DeleteBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime dateTime);
        /// <summary>
        /// Finds all tickets from departureTown to arrivalTown
        /// </summary>
        /// <param name="departureTown">The departure town</param>
        /// <param name="arrivalTown">The arrival town</param>
        /// <returns>Returns the tickets or "Not found" message otherwise.</returns>
        string FindTickets(string departureTown, string arrivalTown);

        /// <summary>
        /// Finds all tickets from startDate to endDate.
        /// </summary>
        /// <param name="startDateTime">The departure date and time</param>
        /// <param name="endDateTime">The end departure date and time</param>
        /// <returns>Returns the tickets form startDate to endDate or "Not found" message</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}