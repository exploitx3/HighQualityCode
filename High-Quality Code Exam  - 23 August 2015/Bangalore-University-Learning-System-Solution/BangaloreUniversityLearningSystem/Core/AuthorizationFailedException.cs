namespace BangaloreUniversityLearningSystem.Core
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException()
            : base("The current user is not authorized to perform this operation.")
        {
        }
    }
}
