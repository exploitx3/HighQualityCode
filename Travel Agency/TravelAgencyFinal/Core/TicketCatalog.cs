namespace TravelAgency.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Enums;
    using Interfaces;
    using Models.Tickets;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly Dictionary<string, Ticket> ticketsByKey = new Dictionary<string, Ticket>();
        private readonly MultiDictionary<string, Ticket> ticketsByDepartureArrivalKey = new MultiDictionary<string, Ticket>(true);
        private readonly OrderedMultiDictionary<DateTime, Ticket> ticketsByDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);

        private int airTicketsCount;
        private int busTicketsCount;
        private int trainTicketsCount;

        public string FindTickets(string departureTown, string arrivalTown)
        {
            string departureArrivalKey = Ticket.CreateDepartureArrivalKey(departureTown, arrivalTown);

            if (this.ticketsByDepartureArrivalKey.ContainsKey(departureArrivalKey))
            {
                var ticketsFound = this.ticketsByDepartureArrivalKey[departureArrivalKey];
                ////PERFORMANCE: Unneded foreach loop.

                string ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }

            return "Not found";
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);

            string result = this.AddDeleteTicket(ticket, false);
            if (result == "Ticket deleted")
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return this.airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount; 
        }

        public int GetTicketsCount(string type)
        {
            if (type == "air")
            {
                return this.airTicketsCount;
            }

            if (type == "bus")
            {
                return this.busTicketsCount;
            }

            return this.trainTicketsCount;
        }

        public string AddAirTicket(
            string flightNumber,
            string departureTown,
            string arrivalTown,
            string airline,
            DateTime dateAndTime,
            decimal price)
        {
            AirTicket ticket = new AirTicket(flightNumber, departureTown, arrivalTown, airline, dateAndTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());

            string result = this.AddDeleteTicket(ticket, true);
            if (result == "Ticket added")
            {
                this.airTicketsCount++;
            }

            return result;
        }

        public string AddTrainTicket(
            string departureTown,
            string arrivalTown,
            DateTime dateAndTime,
            decimal regularPrice,
            decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(
                departureTown,
                arrivalTown,
                dateAndTime.ToString("dd.MM.yyyy HH:mm"),
                regularPrice.ToString(),
                studentPrice.ToString());

            string result = this.AddDeleteTicket(ticket, true);
            if (result == "Ticket added")
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(string departureTown, string arrivalTown, DateTime dateTime)
        {
            TrainTicket ticket = new TrainTicket(departureTown, arrivalTown, dateTime.ToString("dd.MM.yyyy HH:mm"));
            string result = this.AddDeleteTicket(ticket, false);

            if (result == "Ticket deleted")
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(
            string departureTown,
            string arrivalTown,
            string travelCompany,
            DateTime date,
            decimal price)
        {
            BusTicket ticket = new BusTicket(
                departureTown,
                arrivalTown,
                travelCompany,
                date.ToString("dd.MM.yyyy HH:mm"),
                price.ToString());

            string result = this.AddDeleteTicket(ticket, true);

            if (result == "Ticket added")
            {
                this.busTicketsCount++;
            }

            return result;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDateTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = ReadTickets(ticketsFound);

                return ticketsAsString;
            }

            return "Not found";
        }

        public string ExecuteCommand(string line)
        {
            if (line == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string commandName = line.Substring(0, firstSpaceIndex);
            DateTime dateTime;
            decimal price;
            string commandResult = "Invalid command!";
            switch (commandName)
            {
                case "AddAir":
                    string allParameters = line.Substring(firstSpaceIndex + 1);
                    string[] parameters = allParameters.Split(
                        new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    dateTime = DateTime.ParseExact(parameters[4].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

                    price = decimal.Parse(parameters[5].Trim());
                    commandResult = this.AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], dateTime, price);
                    break;
                case "DeleteAir":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandResult = this.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    dateTime = DateTime.ParseExact(parameters[2].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    decimal regularPrice = decimal.Parse(parameters[3].Trim());
                    decimal studentPrice = decimal.Parse(parameters[4].Trim());
                    commandResult = this.AddTrainTicket(
                        parameters[0],
                        parameters[1],
                        dateTime,
                        regularPrice,
                        studentPrice);

                    break;
                case "DeleteTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    dateTime = DateTime.ParseExact(parameters[2].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    commandResult = this.DeleteTrainTicket(
                        parameters[0],
                        parameters[1],
                        dateTime);
                    break;
                case "AddBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    dateTime = DateTime.ParseExact(parameters[3].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    price = decimal.Parse(parameters[4].Trim());
                    commandResult = this.AddBusTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        dateTime,
                        price);
                    break;
                case "DeleteBus":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    dateTime = DateTime.ParseExact(parameters[3].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    commandResult = this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], dateTime);

                    break;
                case "FindTickets":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                
                    commandResult = this.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    DateTime startDateTime = Ticket.ParseDateTime(parameters[0]);
                    DateTime endDateTime = Ticket.ParseDateTime(parameters[1]);

                    commandResult = this.FindTicketsInInterval(startDateTime, endDateTime);
                    break;
            }

            return commandResult;
        }

        public string DeleteBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime dateTime)
        {
            BusTicket ticket = new BusTicket(departureTown, arrivalTown, travelCompany, dateTime.ToString("dd.MM.yyyy HH:mm"));
            string result = this.AddDeleteTicket(ticket, false);

            if (result.Contains("deleted"))
            {
                this.busTicketsCount--;
            }

            return result;
        }

        private static string ReadTickets(ICollection<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);

            sortedTickets.Sort();
            string result = string.Join(" ", sortedTickets);
            ////        Performance: Unneeded 
            return result;
        }

        private string AddDeleteTicket(Ticket ticket, bool isAdd)
        {
            if (isAdd)
            {
                string key = ticket.TicketKey;
                if (this.ticketsByKey.ContainsKey(key))
                {
                    return "Duplicate ticket";
                }

                this.ticketsByKey.Add(key, ticket);
                string departureArrivalKey = ticket.DepartureArrivalKey;

                this.ticketsByDepartureArrivalKey.Add(departureArrivalKey, ticket);

                this.ticketsByDateTime.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
            else
            {
                string key = ticket.TicketKey;

                if (this.ticketsByKey.ContainsKey(key))
                {
                    ticket = this.ticketsByKey[key];
                    this.ticketsByKey.Remove(key);
                    string departureTownToKey = ticket.DepartureArrivalKey;

                    this.ticketsByDepartureArrivalKey.Remove(departureTownToKey, ticket);

                    this.ticketsByDateTime.Remove(ticket.DateAndTime, ticket);
                    return "Ticket deleted";
                }

                return "Ticket does not exist";
            }
        }
    }
}