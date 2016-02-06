namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Infrastructure;
    using Models;

    public class Login : View
    {
        public Login(User user) 
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged in successfully.", user.Username).AppendLine();
        }
    }
}
