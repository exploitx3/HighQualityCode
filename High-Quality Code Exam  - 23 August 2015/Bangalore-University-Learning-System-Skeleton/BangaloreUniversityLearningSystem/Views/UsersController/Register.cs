namespace BangaloreUniversityLearningSystem.Views.UsersController
{
    using System.Text;
    using Models;

    public class Register : ViewBase
    {
        public Register(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", (this.Model as User).Username).AppendLine();
        }
    }
}