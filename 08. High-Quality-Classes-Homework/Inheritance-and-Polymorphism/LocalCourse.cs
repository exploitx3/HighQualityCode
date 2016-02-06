using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base (name)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base (courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("The lab cannot be empty", "Lab");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Insert(0,"Local");
           
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            //Closes the opening curly bracked in the base class
            result.Append(" }");

            return result.ToString();
        }
    }
}
