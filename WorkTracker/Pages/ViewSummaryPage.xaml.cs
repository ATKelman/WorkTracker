using System.Threading;
using System.Windows.Controls;
using Youtrack;
using WorkTracker.UserControls;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Collections;

namespace WorkTracker.Pages
{
    /// <summary>
    /// Interaction logic for ViewSummaryPage.xaml
    /// </summary>
    public partial class ViewSummaryPage : Page
    {
        private Youtrack.Youtrack youtrack;
        private IList<YouTrackSharp.Issues.Issue> issues;

        private YoutrackIssue[] displayIssues;
        private int pageCounter = 0;

        private Dictionary<string, List<YouTrackSharp.Projects.CustomField>> projects;

        private const int IssuesPerPage = 3;

        public ViewSummaryPage(int youtrackIssuesCount)
        {
            InitializeComponent();

            DisplayIssuesSetup(youtrackIssuesCount);

            Thread youtrackSetup = new Thread(YoutrackSetup);
            youtrackSetup.Start();
        }

        private void DisplayIssuesSetup(int youtrackIssuesCount)
        {
            displayIssues = new YoutrackIssue[youtrackIssuesCount];
            for (int i = 0; i < youtrackIssuesCount; i++)
            {
                displayIssues[i] = new YoutrackIssue();

                SummaryGrid.Children.Add(displayIssues[i]);
                Grid.SetColumn(displayIssues[i], i + 1);
            }
        }

        private void YoutrackSetup()
        {
            youtrack = new Youtrack.Youtrack();
            issues = (IList<YouTrackSharp.Issues.Issue>)youtrack.GetIssues("#{Assigned to me}");

            projects = new Dictionary<string, List<YouTrackSharp.Projects.CustomField>>();

            // Get all types of projects 
            foreach (var issue in issues)
            {
                var projectName = issue.GetField("projectShortName").Value.ToString();
                if (projects.ContainsKey(projectName))
                    continue;

                // Retrieve all CustomFields for the Project
                var customFields = (List<YouTrackSharp.Projects.CustomField>)youtrack.GetCustomFields(projectName);

                projects.Add(projectName, customFields);
            }

            FillPage(pageCounter);
        }

        private void FillPage(int pageCount)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                for (int i = 0; i < IssuesPerPage; i++)
                {
                    var issueCount = (pageCount * IssuesPerPage) + i;
                    if (issues.Count > issueCount)
                    {
                        displayIssues[i].MaxHeight = 350;
                        displayIssues[i].MaxWidth = 180;

                        displayIssues[i].HeaderText.Text = issues[issueCount].Summary;
                        displayIssues[i].DescriptionText.Text = issues[issueCount].Description;

                        displayIssues[i].Visibility = Visibility.Visible;
                    }
                    else
                    {
                        displayIssues[i].Visibility = Visibility.Hidden;
                    }
                }
            });
        }

        private void ButtonPressed(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var change = int.Parse(button.Tag.ToString());

            pageCounter = Math.Max((pageCounter + change), 0);

            if (pageCounter == 0)
            {
                PreviousButton.IsEnabled = false;
            }
            else if ((pageCounter * IssuesPerPage) + (IssuesPerPage - 1) > issues.Count)
            {
                NextButton.IsEnabled = false;
            }
            else
            {
                PreviousButton.IsEnabled = true;
                NextButton.IsEnabled = true;
            }
            FillPage(pageCounter);
        }
    }
}
