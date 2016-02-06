﻿namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using Models;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> CommentsByUser { get; }

        void AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}