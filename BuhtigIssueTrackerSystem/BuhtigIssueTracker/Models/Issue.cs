namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities;
    using Enums;

    public class Issue
    {
        private string title;
        private string description;

        public Issue(string title, string description, IssuePriority priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinIssueTitleLength)
                {
                    throw new ArgumentException(
                        $"The title must be at least {Constants.MinIssueTitleLength} symbols long");
                }
                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinIssueDescriptionLength)
                {
                    throw new ArgumentException(
                        $"The description must be at least {Constants.MinIssueDescriptionLength} symbols long");
                }
                this.description = value;
            }
        }
        
        public IssuePriority Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IList<Comment> Comments { get; set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();
            issue.AppendLine(this.Title)
                .AppendFormat("Priority: {0}", this.GetPriorityAsString())
                .AppendLine()
                .AppendLine(this.Description);
            //Check if this works.
            this.AppendTags(issue);

            this.AppendComments(issue);

            return issue.ToString().Trim();
        }

        private void AppendComments(StringBuilder issue)
        {
            if (this.Comments.Count > 0)
            {
                string allComments = string.Join(Environment.NewLine, this.Comments);
                issue.AppendFormat("Comments:{0}{1}", Environment.NewLine, allComments).AppendLine();
            }
        }

        private void AppendTags(StringBuilder issue)
        {
            if (this.Tags.Count > 0)
            {
                var orderedTags = this.Tags.OrderBy(t => t);
                issue.AppendFormat("Tags: {0}", string.Join(",", orderedTags)).AppendLine();
            }
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriority.Showstopper:
                    return "****";
                case IssuePriority.High:
                    return "***";
                case IssuePriority.Medium:
                    return "**";
                case IssuePriority.Low:
                    return "*";
                default: throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}