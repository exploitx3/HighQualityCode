namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T item);
    }
}