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

        private Dictionary<string, List<Tuple<YouTrackSharp.Projects.CustomField, string >>> issuesFields;

        private const int IssuesPerPage = 3;

        public ViewSummaryPage(int youtrackIssueCount, int youtrackIssueWidth, int youtrackIssueHeight)
        {
            InitializeComponent();

            DisplayIssuesSetup(youtrackIssueCount, youtrackIssueWidth, youtrackIssueHeight);

            Thread youtrackSetup = new Thread(YoutrackSetup);
            youtrackSetup.Start();
        }

        private void DisplayIssuesSetup(int youtrackIssueCount, int youtrackIssueWidth, int youtrackIssueHeight)
        {
            displayIssues = new YoutrackIssue[youtrackIssueCount];
            for (int i = 0; i < youtrackIssueCount; i++)
            {
                displayIssues[i] = new YoutrackIssue();

                displayIssues[i].Height = youtrackIssueHeight;
                displayIssues[i].Width = youtrackIssueWidth;

                SummaryGrid.Children.Add(displayIssues[i]);
                Grid.SetColumn(displayIssues[i], i + 1);
            }
        }

        private void YoutrackSetup()
        {
            youtrack = new Youtrack.Youtrack();
            issues = (IList<YouTrackSharp.Issues.Issue>)youtrack.GetIssues("#{Assigned to me}");

            issuesFields = new Dictionary<string, List<Tuple<YouTrackSharp.Projects.CustomField, string>>>();

            // Get all customField info for each issue  
            foreach (var issue in issues)
            {
                if (issuesFields.ContainsKey(issue.Id))
                    continue;

                var projectName = issue.GetField("projectShortName").Value.ToString();

                // Retrieve all CustomFields for the Project
                var fields = new List<Tuple<YouTrackSharp.Projects.CustomField, string>>();

                var customFields = (List<YouTrackSharp.Projects.CustomField>)youtrack.GetCustomFields(projectName);

                foreach (var customField in customFields)
                {
                    var customFieldInfo = youtrack.GetIssueCustomField(projectName, customField.Name);
                    fields.Add(new Tuple<YouTrackSharp.Projects.CustomField, string>(customField, customFieldInfo.Name));
                }

                issuesFields.Add(issue.Id, fields);
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
                        displayIssues[i].HeaderText.Text = issues[issueCount].Summary;
                        displayIssues[i].DescriptionText.Text = issues[issueCount].Description;

                        //// Fill CustomFields 
                        displayIssues[i].IssueFields.Children.Clear();

                        foreach (var field in issuesFields[issues[issueCount].Id])
                        {
                            var label = new Label();
                            label.Content = string.Format("{0}: {1}", field.Item1.Name, field.Item2);

                            displayIssues[i].IssueFields.Children.Add(label);
                        }

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
