namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Infrastructure;
    using Interfaces;
    using Models;

    public class BangaloreUniversityEngine : IEngine
    {
        public void Run()
        {
            var database = new BangaloreUniversityData();
            User currentUser = null;
            while (true)
            {
                string routeUrl = Console.ReadLine();
                if (routeUrl == null)
                {
                    break;
                }

                var route = new Route(routeUrl);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
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
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            return int.Parse(route.Parameters[p.Name]);
                        }
                        else
                        {
                            return route.Parameters[p.Name];
                        }   
                    })
               .ToArray();

            return parameters;
        }
    }
}
