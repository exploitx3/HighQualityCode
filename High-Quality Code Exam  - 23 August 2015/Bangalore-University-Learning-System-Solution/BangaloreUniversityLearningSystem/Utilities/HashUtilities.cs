namespace BangaloreUniversityLearningSystem.Utilities
{
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtilities
    {
        public static string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

       private static string HexStringFromBytes(byte[] bytes)
        {
            var result = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                result.Append(hex);
            }

            return result.ToString();
        }
    }
}
