namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;
    using Utilities;

    public class Comment
    {
        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.MinCommentTextLength)
                {
                    throw new ArgumentException(
                        $"The text must be at least {Constants.MinCommentTextLength} symbols long");
                }
                this.text = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().AppendLine(Text).AppendFormat("-- {0}", Author.Username).AppendLine().ToString().Trim();
        }
    }
}
