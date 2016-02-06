namespace BuhtigIssueTracker.Interfaces
{
    using Enums;

    /// <summary>
    /// Contains methods for working with an issue tracker system.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Registers a user to the database.
        /// </summary>
        /// <param name="username">The username of the user to register</param>
        /// <param name="password">The password of the user to register</param>
        /// <param name="confirmPassword">The password confirmation of the user to register.
        /// In order to be a valid registration, the password and the confirmation password must match.</param>
        /// <returns>Returns a success message in case of successful registration, and an error message otherwise. </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        string LoginUser(string username, string PasswordHash);// TODO: Dokumentieren Sie diese Methode

        string LogoutUser();// TODO: Dokumentieren Sie diese Methode

        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);// TODO: Dokumentieren Sie diese Methode

        string RemoveIssue(int issueId);// TODO: Dokumentieren Sie diese Methode

        string AddComment(int issueId, string text);// TODO: Dokumentieren Sie diese Methode

        string GetMyIssues();// TODO: Dokumentieren Sie diese Methode

        string GetMyComments();// TODO: Dokumentieren Sie diese Methode

        string SearchForIssues(string[] tags);// TODO: Dokumentieren Sie diese Methode
    }
}