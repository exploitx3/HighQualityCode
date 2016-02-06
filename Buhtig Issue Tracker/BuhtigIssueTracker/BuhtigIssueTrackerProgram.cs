namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;

    class BuhtigIssueTrackerProgram
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new BuhtigIssueTrackerEngine();
            engine.Run();
        }
    }
}