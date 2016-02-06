namespace BangaloreUniversityLearningSystem
{
    using System.Collections.Generic;
    using Core;
    using Data;
    using Interfaces;
    using Models;

    public class LearningSystemMain
    {
        public static void Main()
        {
            IUsersRepository usersRepository = new UsersRepository();
            IRepository<Course> courseRepository = new Repository<Course>();
            IBangaloreUniversityDatebase database = new BangaloreUniversityDatebase(usersRepository, courseRepository);

            var engine = new BangaloreUniversityEngine(database);

            engine.Run();
        }
    }
}