namespace BangaloreUniversityLearningSystem.Core.Interfaces
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}
