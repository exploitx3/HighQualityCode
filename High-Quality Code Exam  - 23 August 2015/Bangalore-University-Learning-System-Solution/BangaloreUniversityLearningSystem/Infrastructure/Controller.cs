namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Core;
    using Core.Interfaces;
    using Models;
    using Utilities;

    public abstract class Controller
    {
        protected Controller(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public User CurrentUser { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IBangaloreUniversityData Data { get; private set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamespaceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException();
            }
        }
    }
}
