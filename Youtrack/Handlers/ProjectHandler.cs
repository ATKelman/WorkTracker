using System.Collections.Generic;
using System.Threading.Tasks;
using Youtrack.Utilities;
using YouTrackSharp;

namespace Youtrack.Handlers
{
    public static class ProjectHandler
    {
        // GetProjects
        public static ICollection<YouTrackSharp.Projects.Project> GetProjects(BearerTokenConnection connection)
        {
            var task = connection.CreateProjectsService().GetAccessibleProjects();

            var projects = Tasks.AwaitTask<ICollection<YouTrackSharp.Projects.Project>>(task);

            return projects.Result;
        }

        // GetProjectCustomField
        public static YouTrackSharp.Projects.CustomField GetIssueCustomField(BearerTokenConnection connection, string projectId, string fieldId)
        {
            var task = connection.ProjectCustomFieldsService().GetProjectCustomField(projectId, fieldId);

            var customField = Tasks.AwaitTask<YouTrackSharp.Projects.CustomField>(task);

            return customField.Result;
        }

        // GetProjectCustomFields
        public static ICollection<YouTrackSharp.Projects.CustomField> GetIssueCustomFields(BearerTokenConnection connection, string projectId)
        {
            var task = connection.ProjectCustomFieldsService().GetProjectCustomFields(projectId);

            var customFields = Tasks.AwaitTask<ICollection<YouTrackSharp.Projects.CustomField>>(task);

            return customFields.Result;
        }

        // ** CreateProjectCustomField

        // ** DeleteProjectCustomField

        // ** UpdateProjectCustomField
    }
}
