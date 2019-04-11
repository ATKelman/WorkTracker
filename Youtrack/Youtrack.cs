using System;
using System.Collections.Generic;
using YouTrackSharp;
using Youtrack.Handlers;

namespace Youtrack
{
    public class Youtrack
    {
        private BearerTokenConnection connection;

        public Youtrack()
        {
            OpenConnection();
        }

        private bool OpenConnection()
        {
            try
            {
                // Change so they are injected 
                var uri = System.Configuration.ConfigurationManager.AppSettings["YoutrackUri"];
                var token = System.Configuration.ConfigurationManager.AppSettings["YoutrackToken"];

                connection = new BearerTokenConnection(uri, token);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Issue
        public YouTrackSharp.Issues.Issue GetIssue(string issueId) => IssueHandler.GetIssue(connection, issueId);
        public ICollection<YouTrackSharp.Issues.Issue> GetIssues(string query) => IssueHandler.GetIssues(connection, query);
        public bool CreateIssue(Classes.Issue issue) => IssueHandler.CreateIssue(connection, issue);

        // Project
        public ICollection<YouTrackSharp.Projects.Project> GetProjects() => ProjectHandler.GetProjects(connection);
        public YouTrackSharp.Projects.CustomField GetIssueCustomField(string projectId, string fieldId) => ProjectHandler.GetIssueCustomField(connection, projectId, fieldId);
        public ICollection<YouTrackSharp.Projects.CustomField> GetCustomFields(string projectId) => ProjectHandler.GetIssueCustomFields(connection, projectId);
    }
}
