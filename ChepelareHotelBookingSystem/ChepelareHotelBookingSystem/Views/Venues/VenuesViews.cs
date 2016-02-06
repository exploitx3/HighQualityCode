namespace ChepelareHotelBookingSystem.Views.Venues
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;

    public class All : View
    {
        public All(IEnumerable<Venue> venues)
            : base(venues)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venues = this.Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    viewResult.AppendFormat("*[{0}] {1}, located at {2}", venue.Id, venue.Name, venue.Address).AppendLine()
                        .AppendFormat("Free rooms: {0}", venue.Rooms.Count).AppendLine();
                }
            }
        }
    }

    public class Details : View
    {
        public Details(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine(venue.Name)
                .AppendFormat("Located at {0}", venue.Address).AppendLine()
                .AppendFormat("Description: {0}", venue.Description).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                viewResult.AppendLine("Available rooms:");
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" * {0} places (${1:F2} per day)", room.Places, room.PricePerDay).AppendLine();
                }
            }
        }
    }

 
    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.", venue.Name, venue.Id).AppendLine();
        }
    }
}