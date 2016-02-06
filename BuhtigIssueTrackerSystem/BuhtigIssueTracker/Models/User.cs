using BuhtigIssueTracker.Utilities;

namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.PasswordHash = HashUtilities.HashPassword(password);
        }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
       
      
    }
}