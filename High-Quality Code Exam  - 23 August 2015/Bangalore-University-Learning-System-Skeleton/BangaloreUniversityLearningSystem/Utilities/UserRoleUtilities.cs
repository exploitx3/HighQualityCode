﻿namespace BangaloreUniversityLearningSystem.Utilities
{
    using Enum;
    using Models;

    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }
    }
}
