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

            // Get all unique projects
            projects = new Dictionary<string, List<YouTrackSharp.Projects.CustomField>>();
            foreach (var issue in issues)
            {
                var projectName = issue.GetField("projectShortName").Value.ToString();
                if (projects.ContainsKey(projectName))
                    continue;

                var projectCustomFields = (List<YouTrackSharp.Projects.CustomField>)youtrack.GetCustomFields(projectName);
                projects.Add(projectName, projectCustomFields);
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

                        // Fill CustomFields 
                        displayIssues[i].IssueFields.Children.Clear();

                        var projectName = issues[issueCount].GetField("projectShortName").Value.ToString();
                        var test = projects[projectName];
                        foreach (var field in projects[projectName])
                        {
                            var label = new Label();
                            var fieldValue = GetFormattedCustomFieldValue(field.Name, issues[issueCount].GetField(field.Name));

                            label.Content = $"{field.Name}: {fieldValue}";

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

        // Formats CustomfFieldValue based customField DataType in the field value 
        private string GetFormattedCustomFieldValue(string customFieldName, YouTrackSharp.Issues.Field field)
        {
            string customFieldValue;
            try
            {
                customFieldValue = field.Value.ToString();
            }
            catch (Exception ex)
            {
                // TODO notify user or log 
                customFieldValue = "[Missing]";
            }

            return customFieldValue;
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
