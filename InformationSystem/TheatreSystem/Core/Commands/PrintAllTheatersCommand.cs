namespace TheatreSystem.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class PrintAllTheatersCommand : BaseCommand
    {
        public PrintAllTheatersCommand(string[] args, IPerformanceDatabase performanceDatabase) : base(args, performanceDatabase)
        {
        }

        public override string Execute()
        {
            var theatresCount = this.PerformanceDatabase.ListTheatres().Count();

            if (theatresCount > 0)
            {
                return String.Join(", ", this.PerformanceDatabase.ListTheatres());
            }
            else
            {
                return "No theatres";
            }
        }
    }
}