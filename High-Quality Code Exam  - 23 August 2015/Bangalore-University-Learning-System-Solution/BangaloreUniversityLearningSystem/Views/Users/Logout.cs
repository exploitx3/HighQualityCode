namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Infrastructure;
    using Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged out successfully.", user.Username).AppendLine();
        }
    }
}
