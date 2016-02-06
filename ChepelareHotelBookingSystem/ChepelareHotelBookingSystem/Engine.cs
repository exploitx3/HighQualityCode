namespace ChepelareHotelBookingSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Data;
    using HotelBookingSystem.Models;
    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    public class Engine : IEngine
    {
        public void Run()
        {
            var database = new HotelBookingSystemData();
            User currentUser = null;
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        type => type.Name == executionEndpoint.ControllerName);

                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;

                var action = controllerType.GetMethod(executionEndpoint.ActionName);

                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                Console.WriteLine(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(parameter =>
                {
                    if (parameter.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[parameter.Name]);
                    }
                    if (parameter.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(executionEndpoint.Parameters[parameter.Name], Constants.DateFormat, CultureInfo.InvariantCulture);
                    }
                    if (parameter.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[parameter.Name]);
                    }

                    return executionEndpoint.Parameters[parameter.Name];
                })
               .ToArray();

            return parameters;
        }
    }
}
