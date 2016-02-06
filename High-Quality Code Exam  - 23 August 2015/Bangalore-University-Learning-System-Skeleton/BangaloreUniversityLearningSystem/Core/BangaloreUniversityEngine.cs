namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Models;

    public class BangaloreUniversityEngine : IEngine
    {
        private readonly IBangaloreUniversityDatebase database;

        public BangaloreUniversityEngine(IBangaloreUniversityDatebase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("Database cannot be null");
            }

            this.database = database;
        }

        public void Run()
        {
            User user = null;
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == null)
                {
                    break;
                }

                var route = new Route(inputLine);

                var controllerType =
                    Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, this.database, user) as ControllerBase;
                var action = controllerType.GetMethod(route.ActionName);

                object[] @params = MapParameters(route, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, @params) as IView;
                    viewResult = view.Display();

                    user = controller.User;
                }
                catch (Exception ex)
                {
                    viewResult = ex.InnerException.Message;
                }

                Console.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
//            var result = action
//                .GetParameters()
//                .Select<ParameterInfo, object>(p =>
//                    {
//                        if (p.ParameterType == typeof(int))
//                        {
//                            return int.Parse(route.Parameters[p.Name]);
//                        }
//                        else
//                        {
//                            return route.Parameters[p.Name];
//                        }
//                    }).ToArray();
//
//            return result;
            var expectedParameters = action.GetParameters();
            var argumentsToPass = new List<object>();

            foreach (ParameterInfo param in expectedParameters)
            {
                var currentArgument = route.Parameters[param.Name];
                if (param.ParameterType == typeof (int))
                {
                    argumentsToPass.Add(int.Parse(currentArgument));
                }
                else
                {
                    argumentsToPass.Add(currentArgument);
                }
            }

            return argumentsToPass.ToArray();
        }
    }
}
