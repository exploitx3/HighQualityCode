namespace BuhtigIssueTracker.Execution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
        {
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.CreateEndPointWithParameters(url, questionMarkIndex);
            }
            else
            {
                this.ActionName = url;
            }
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void CreateEndPointWithParameters(string url, int questionMark)
        {
            this.ActionName = url.Substring(0, questionMark);
            var parameterKeyValuePairs = url
                .Substring(questionMark + 1)
                .Split('&');
            var keysAndValues = parameterKeyValuePairs
                .Select(pair => pair.Split('=')
                    .Select(item => WebUtility.UrlDecode(item))
                    .ToArray());

            var parameters = new Dictionary<string, string>();
            foreach (var pair in keysAndValues)
            {
                parameters.Add(pair[0], pair[1]);
            }

            this.Parameters = parameters;
        }

       
    }
}