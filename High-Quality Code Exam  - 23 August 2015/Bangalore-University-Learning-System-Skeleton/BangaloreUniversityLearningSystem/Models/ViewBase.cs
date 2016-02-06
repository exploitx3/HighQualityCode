namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class ViewBase : IView
    {
        private object model;

        protected ViewBase(object model)
        {
            this.Model = model;
        }

        public object Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The view model cannot be null");
                }

                this.model = value;
            }
        }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        internal abstract void BuildViewResult(StringBuilder viewResult);
    }
}