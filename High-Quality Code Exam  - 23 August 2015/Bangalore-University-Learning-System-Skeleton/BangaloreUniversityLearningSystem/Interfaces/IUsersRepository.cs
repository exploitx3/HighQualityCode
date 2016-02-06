namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Models;

    public interface IUsersRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}