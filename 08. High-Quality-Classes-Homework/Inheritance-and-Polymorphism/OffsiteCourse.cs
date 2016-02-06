using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base (name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base (courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("The town cannot be empty", "Town");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Insert(0, "Offsite");
           
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            //Closes the opening curly bracked in the base class
            result.Append(" }");

            return result.ToString();
        }
    }
}
