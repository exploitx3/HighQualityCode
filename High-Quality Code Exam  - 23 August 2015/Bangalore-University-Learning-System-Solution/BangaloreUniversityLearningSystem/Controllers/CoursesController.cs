namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Core.Interfaces;
    using Infrastructure;
    using Models;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var courses = this.Data.Courses
                .GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count);
            return this.View(courses);
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.GetCourseById(courseId);
            if (!this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.GetCourseById(courseId);
            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.CurrentUser);
            return this.View(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);

            Course course = this.GetCourseById(courseId);
            var lecture = new Lecture(lectureName);
            course.AddLecture(lecture);
            return this.View(course);
        }

        private Course GetCourseById(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}
