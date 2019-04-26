using System;
using System.Collections.Generic;
using Youtrack.Classes;
using YouTrackSharp;

namespace Youtrack.Handlers
{
    public static class IssueHandler
    {
        // GetIssue
        public static YouTrackSharp.Issues.Issue GetIssue(BearerTokenConnection connection, string issueId)
        {
            var issue = connection.CreateIssuesService().GetIssue(issueId);

            return issue.Result;
        }

        // GetIssues
        public static ICollection<YouTrackSharp.Issues.Issue> GetIssues(BearerTokenConnection connection, string query)
        {
            var issues = connection.CreateIssuesService().GetIssues(query);

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

            try
            {
                connection.CreateIssuesService().CreateIssue("OTHER", newIssue).Wait();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // EditIssue

        // ** DeleteIssue

        // CommentOnIssue

        // ** RemoveACommentOnIssue
    }
}