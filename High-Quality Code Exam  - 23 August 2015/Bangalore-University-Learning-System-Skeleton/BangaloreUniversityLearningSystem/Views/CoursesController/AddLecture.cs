namespace BangaloreUniversityLearningSystem.Views.CoursesController
{
    using System.Text;
    using Models;

    public class AddLecture : ViewBase
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}