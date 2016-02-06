namespace TheatreSystem.Core.Commands
{
    using System.Linq;
    using Interfaces;

    public class PrintPerformancesCommand : BaseCommand
    {
        public PrintPerformancesCommand(string[] args, IPerformanceDatabase performanceDatabase) : base(args, performanceDatabase)
        {
        }

        public override string Execute()
        {
            string theatre = this.CommandArgs[0];
            var performances = this.PerformanceDatabase.ListPerformances(theatre)
                .Select(performance =>
                {
                    string dateTime = performance.DateTime.ToString("dd.MM.yyyy HH:mm");

                    return $"({performance.PerformanceName}, {dateTime})";
                })
                .ToList();

            string commandResult;
            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }
            else
            {
                commandResult = "No performances";
            }

            return commandResult;
        }
    }
}