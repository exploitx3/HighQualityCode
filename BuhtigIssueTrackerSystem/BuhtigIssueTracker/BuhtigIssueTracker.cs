using BuhtigIssueTracker.Utilities;

namespace BuhtigIssueTracker {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Interfaces;
    using Enums;
    using Models;

    public class BuhtigIssueTracker : IIssueTracker
    {
        BuhtigIssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data ;
        }

        public BuhtigIssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public IBuhtigIssueTrackerData Data { get; private set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.UsersByUsername.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password) {
            if (this.Data.CurrentUser != null)
            {
                return string.Format("There is already a logged in user");
            }
            if (!this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersByUsername[username];
            if (user.PasswordHash != HashUtilities.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }
            this.Data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser() {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
            string username = this.GetCurrentUsername();
            this.Data.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings) {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var currentUsername = this.GetCurrentUsername();
            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            this.Data.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId) {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }
            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.GetCurrentUsername()].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.GetCurrentUsername());
            }

            this.Data.RemoveIssue(issue);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string text) {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var comment = new Comment(this.Data.CurrentUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues() {
            if (Data.CurrentUser == null)
                return string.Format("There is no currently logged in user");

            var issues = Data.IssuesByUsername[this.GetCurrentUsername()];
            if (!issues.Any())
            {
                // PERFORMANCE : Unneeded operation
                return "No issues";
            }

            var orderedIssues = issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title);
            return string.Join(Environment.NewLine, orderedIssues);
        }

        public string GetMyComments() {
            if (this.Data.CurrentUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
           
            // PERFORMANCE: Values were not retireved from the correct dictionary.
            string currentUser = this.GetCurrentUsername();
            var comments = this.Data.CommentsByUser[this.Data.CurrentUser];
            if (!comments.Any())
            {
                return "No comments";
            }
            var commentsAsStrings = comments.Select(c => c.ToString());
            return string.Join(Environment.NewLine, commentsAsStrings);
        }

        public string SearchForIssues(string[] tags) {
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.IssuesByTag[tag]);
            }
            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var distinctIssues = issues.Distinct();
            if (!distinctIssues.Any())
            {
                return "No issues";
            }

            var orderedDistinctIssues =
                distinctIssues
                .OrderByDescending(i => i.Priority)
                .ThenBy(i => i.Title)
                .Select(i => i.ToString());
            return string.Join(Environment.NewLine, orderedDistinctIssues);
        }

        private string GetCurrentUsername()
        {
            return this.Data.CurrentUser.Username;
        }
    }
}
