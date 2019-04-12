using System.Collections.Generic;
using YouTrackSharp;

namespace Youtrack.Handlers
{
    public static class ProjectHandler
    {
        // GetProjects
        public static ICollection<YouTrackSharp.Projects.Project> GetProjects(BearerTokenConnection connection)
        {
            var projects = connection.CreateProjectsService().GetAccessibleProjects();

            return projects.Result;
        }

        // GetProjectCustomField
        public static YouTrackSharp.Projects.CustomField GetIssueCustomField(BearerTokenConnection connection, string projectId, string fieldId)
        {
            var customField = connection.ProjectCustomFieldsService().GetProjectCustomField(projectId, fieldId);

            return customField.Result;
        }

        // GetProjectCustomFields
        public static ICollection<YouTrackSharp.Projects.CustomField> GetIssueCustomFields(BearerTokenConnection connection, string projectId)
        {
            var customFields = connection.ProjectCustomFieldsService().GetProjectCustomFields(projectId);

            return customFields.Result;
        }

        // ** CreateProjectCustomField

        // ** DeleteProjectCustomField

        // ** UpdateProjectCustomField
    }
}
