using BuhtigIssueTracker.UserInterface;

namespace BuhtigIssueTracker.Execution
{
    using System;
    using Interfaces;

    public class BuhtigIssueTrackerEngine : IEngine
    {
        private readonly EndpointActionDispatcher dispatcher;

        private readonly IUserInterface userInterface;

        public BuhtigIssueTrackerEngine(EndpointActionDispatcher dispatcher, IUserInterface userInterface)
        {
            this.dispatcher = dispatcher;
            this.userInterface = userInterface;
        }

        public BuhtigIssueTrackerEngine()
            : this(new EndpointActionDispatcher(), new ConsoleUserInterface())
        {
            // DI: Custom user interface added
        }

        public void Run()
        {
            while (true)
            {
                string url = this.userInterface.ReadLine();
                if (url == null)
                {
                    break;
                }
                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        this.userInterface.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }

    }
}