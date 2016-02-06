namespace TheatreSystem.Core.Commands
{
    using Interfaces;

    public class AddTheatreCommand : BaseCommand
    {
        public AddTheatreCommand(string[] args, IPerformanceDatabase performanceDatabase) : base(args, performanceDatabase)
        {
        }

        public override string Execute()
        {
            string theatreName = this.CommandArgs[0];
            this.PerformanceDatabase.AddTheatre(theatreName);
            return "Theatre added";
        }
    }
}