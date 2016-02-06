namespace BuhtigIssueTracker.Utilities
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtilities
    {
        public static string HashPassword(string PasswordHash)
        {
            return string.Join(
                string.Empty,
                SHA1.Create().
                    ComputeHash(Encoding.Default.GetBytes(PasswordHash))
                   .Select(x => x.ToString()));
        }
    }
}