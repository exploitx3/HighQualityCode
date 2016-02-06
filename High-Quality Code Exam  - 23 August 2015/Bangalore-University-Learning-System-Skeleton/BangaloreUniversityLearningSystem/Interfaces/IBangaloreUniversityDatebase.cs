namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityDatebase
    {
        IUsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}