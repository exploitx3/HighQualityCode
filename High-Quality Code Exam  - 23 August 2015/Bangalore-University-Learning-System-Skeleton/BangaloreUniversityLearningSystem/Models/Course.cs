namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public Course(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5)
            {
                string message = string.Format("The course name must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }

            this.Name = name;

            this.Lectures = new HashSet<Lecture>();
            this.Students = new HashSet<User>();
        }
        
        public string Name { get; set; }

        public ISet<Lecture> Lectures { get; set; }

        public ISet<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
        }
    }
}