namespace BuhtigIssueTracker.Interfaces
{
    using Stuff;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    interface IBuhtigIssueTrackerData
    {
        Benutzer TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem { get; set; }

        IDictionary<string, Benutzer> users_dict { get; }

        OrderedDictionary<int, Problem> issues1 { get; }

        MultiDictionary<string, Problem> issues2 { get; }

        MultiDictionary<string, Problem> issues4 { get; }

        MultiDictionary<Benutzer, Kommentar> dict { get; }

        int AddIssue(Problem p);

        void RemoveIssue(Problem p);
    }
}