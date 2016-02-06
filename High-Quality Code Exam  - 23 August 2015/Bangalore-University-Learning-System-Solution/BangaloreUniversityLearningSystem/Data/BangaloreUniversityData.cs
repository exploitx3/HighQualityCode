namespace BangaloreUniversityLearningSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Core.Interfaces;
    using Models;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; private set; }

        public IRepository<Course> Courses { get; set; }
    }
}
