namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Text;
    using Models;

    public class Create : ViewBase
    {
        public Create(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}