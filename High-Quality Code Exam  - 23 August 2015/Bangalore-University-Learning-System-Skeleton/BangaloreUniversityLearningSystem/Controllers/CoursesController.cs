﻿namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Enum;
    using Interfaces;
    using Models;
    using Utilities;

    public class CoursesController : ControllerBase
    {
        public CoursesController(IBangaloreUniversityDatebase data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data
                .Courses
                .GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.Data.Courses.GetById(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (!this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.Data.Courses.GetById(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            this.User.EnrollInCourse(course);

            return this.View(course);
        }
        
        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            Course course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture(lectureName));
            return this.View(course);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.GetById(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}
