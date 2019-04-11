using System.Collections.Generic;
using System.Threading.Tasks;
using Youtrack.Classes;
using Youtrack.Utilities;
using YouTrackSharp;

namespace Youtrack.Handlers
{
    public static class IssueHandler
    {
        // GetIssue
        public static YouTrackSharp.Issues.Issue GetIssue(BearerTokenConnection connection, string issueId)
        {
            var task = connection.CreateIssuesService().GetIssue(issueId);

            var issue = Tasks.AwaitTask<YouTrackSharp.Issues.Issue>(task);

            return issue.Result;
        }

        // GetIssues 
        public static ICollection<YouTrackSharp.Issues.Issue> GetIssues(BearerTokenConnection connection, string query)
        {
            var task = connection.CreateIssuesService().GetIssues(query, take: 25);

            var issues = Tasks.AwaitTask<ICollection<YouTrackSharp.Issues.Issue>>(task);

            return issues.Result;
        }

        // CreateIssue 
        public static bool CreateIssue(BearerTokenConnection connection, Issue issue)
        {
            // Create new YoutrackSharp Issue and Set Standard Fields 
            var newIssue = new YouTrackSharp.Issues.Issue()
            {
                Summary = issue.Summary,
                Description = issue.Description,
            };

            // Set CustomFields
            foreach (var customField in issue.CustomFields)
            {
                newIssue.SetField(customField.Name, customField.Value);
            }

            var task = connection.CreateIssuesService().CreateIssue("OTHER", newIssue);

            var issueCreation = Tasks.AwaitTask<string>(task);

            return (issueCreation.Exception == null);
        }

        // EditIssue

        // ** DeleteIssue

        // CommentOnIssue

        // ** RemoveACommentOnIssue
    }
}
