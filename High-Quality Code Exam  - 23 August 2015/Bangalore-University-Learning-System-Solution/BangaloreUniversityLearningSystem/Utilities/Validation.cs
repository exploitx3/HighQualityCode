namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;

    public static class Validation
    {
        public static void ForMinLength(string value, int minLength, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                string message = string.Format("The {0} must be at least {1} symbols long.", paramName, minLength);
                throw new ArgumentException(message);
            }
        }
    }
}
