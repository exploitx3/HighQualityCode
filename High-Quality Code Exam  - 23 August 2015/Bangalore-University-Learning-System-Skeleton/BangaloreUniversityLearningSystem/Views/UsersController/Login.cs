namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;

    public class Login : ViewBase
    {
        public Login(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.Model as User).Username).AppendLine();
        }
    }
}