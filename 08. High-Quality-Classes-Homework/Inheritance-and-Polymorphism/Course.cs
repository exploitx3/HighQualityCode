using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private string name;
        private string teacherName;
        private readonly IList<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.students = new List<string>();
        }

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = students;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name cannot be null or empty", "name");
                }

                this.name = value;
            }
        }
        public string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("The teacher name cannot be empty", "teacherName");
                }

                this.name = value;
            }
        }

        public IEnumerable<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }
        }

        public void AddStudent(string studentName)
        {
            if (string.IsNullOrEmpty(studentName))
            {
                throw new ArgumentException("The student name cannot be null or empty", "studentName");
            }

            this.students.Add(studentName);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count() == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

       
    }
}