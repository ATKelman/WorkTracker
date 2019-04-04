using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YouTrackSharp;

namespace Youtrack
{
    public class Youtrack
    {
        BearerTokenConnection connection;

        public Youtrack()
        {
            OpenConnection();
            GetIssues();
        }

        private bool OpenConnection()
        {
            try
            {
                connection = new BearerTokenConnection("https://cgicfuskara.myjetbrains.com/youtrack", "perm:YWxleGFuZGVyLmtlbG1hbg==.V29ya1RyYWNrZXI=.B7p4sOpuQ57NcGMkkGWamrHMPz6Stz");
                return true;
            }
            catch (Exception ex)
            {
                // Log
                return false;
            }
        }

        public void GetIssues()
        {    
            var query = "resolved date: {Last week} .. Today ";

            var Issues = connection.CreateIssuesService().GetIssues(query, take: 1000);
            //var USersfirst = connection.CreateUserManagementService().GetUsers();
            //var USerssecond = connection.CreateUserManagementService().GetUsers(start: 10);
            //var Projects = connection.CreateProjectsService().GetAccessibleProjects();

            Task[] tasks =
            {
                Issues
                //USersfirst,
                //USerssecond,
                //Projects
            };

            Task.WaitAll(tasks);

            var test = Issues.Result;
            //var query = "resolved date: {Last week} .. Today ";
            //var issues = connection.CreateIssuesService().GetIssues(query, take: 100);

            //Task task = issues;
            //Task.WaitAll(task);
            //var test = issues;
        }
    }
}
