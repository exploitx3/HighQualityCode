namespace TheatreSystem.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class PrintAllPerformancesCommand : BaseCommand
    {
        public PrintAllPerformancesCommand(string[] args, IPerformanceDatabase performanceDatabase) : base(args, performanceDatabase)
        {
        }

        public override string Execute()
        {
            var performances = this.PerformanceDatabase.ListAllPerformances().ToList();
            if (performances.Any())
            {
                return String.Join(", ", performances);
            }

            return "No performances";
        }
    }
}