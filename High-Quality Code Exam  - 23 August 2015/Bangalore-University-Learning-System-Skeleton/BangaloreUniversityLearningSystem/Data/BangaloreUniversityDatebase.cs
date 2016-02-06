namespace BangaloreUniversityLearningSystem.Data
{
    using System;
    using Interfaces;
    using Models;

    public class BangaloreUniversityDatebase : IBangaloreUniversityDatebase
    {
        private IUsersRepository usersRepository;
        private IRepository<Course> coursesRepository; 

        public BangaloreUniversityDatebase(IUsersRepository usersRepository, IRepository<Course> coursesRepository)
        {
            this.Users = usersRepository;
            this.Courses = coursesRepository;
        }

        public IUsersRepository Users
        {
            get
            {
                return this.usersRepository;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Users repository cannot be null");
                }

                this.usersRepository = value;
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.coursesRepository;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Courses repository cannot be null");
                }

                this.coursesRepository = value;
            }
        }
    }
}
