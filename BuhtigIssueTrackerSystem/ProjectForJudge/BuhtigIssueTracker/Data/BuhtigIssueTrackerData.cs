namespace BuhtigIssueTracker.Data
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using Interfaces;
    using Models;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        private int nextIssueId;

        public BuhtigIssueTrackerData()
        {
            this.nextIssueId = 1;
            this.UsersByUsername = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<User, Comment>(true);
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> CommentsByUser { get; set; }


        public void AddIssue(Issue issue)
        {
            issue.Id = this.nextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.nextIssueId++;

            this.IssuesByUsername[this.CurrentUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Add(issue);
            }
            
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.CurrentUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Remove(issue);
            }
            this.IssuesById.Remove(issue.Id);
        }
    }
}