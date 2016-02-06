namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;

    public class Logout : ViewBase
    {
        public Logout(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.Append($"User {(this.Model as User).Username} logged out successfully.");
        }
    }
}