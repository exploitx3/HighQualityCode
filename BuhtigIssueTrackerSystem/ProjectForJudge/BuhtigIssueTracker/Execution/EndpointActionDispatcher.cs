namespace BuhtigIssueTracker.Execution
{
    using Interfaces;
    using Enums;

    public class EndpointActionDispatcher
    {
        EndpointActionDispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }

        public EndpointActionDispatcher() : this(new BuhtigIssueTracker())
        {
        }

        IIssueTracker tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return tracker.RegisterUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"],
                        endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return tracker.LoginUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"]);
                case "LogoutUser":
                    return this.tracker.LogoutUser();
                case "CreateIssue":
                    return tracker.CreateIssue(
                        endpoint.Parameters["title"],
                        endpoint.Parameters["description"],
                        (IssuePriority)System.Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true),
                        endpoint.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return tracker.RemoveIssue(
                        int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    return tracker.AddComment(
                        int.Parse(endpoint.Parameters["id"]),
                        endpoint.Parameters["text"]);
                case "MyIssues":
                    return tracker.GetMyIssues();
                case "MyComments":
                    return tracker.GetMyComments();
                case "Search":
                    return tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}