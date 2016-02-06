namespace TheatreSystem.Core.Commands
{
    using System;
    using System.Globalization;
    using Interfaces;

    public class AddPerformanceCommand : BaseCommand
    {
        public AddPerformanceCommand(string[] args, IPerformanceDatabase performanceDatabase) : base(args, performanceDatabase)
        {
        }

        public override string Execute()
        {
            string theatreName = this.CommandArgs[0];
            string performanceTitle = this.CommandArgs[1];
            DateTime dateTime = DateTime.ParseExact(this.CommandArgs[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(this.CommandArgs[3]);
            decimal price = decimal.Parse(this.CommandArgs[4], CultureInfo.CurrentCulture);

            this.PerformanceDatabase.AddPerformance(theatreName, performanceTitle, dateTime, duration, price);

            string commandResult = "Performance added";
            return commandResult;
        }
    }
}