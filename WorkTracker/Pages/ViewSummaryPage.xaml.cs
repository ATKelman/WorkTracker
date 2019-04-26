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

        public ViewSummaryPage(int youtrackIssuesCount)
        {
            InitializeComponent();

            InitializeYoutrackIssues(youtrackIssuesCount);

            Thread youtrackApi = new Thread(YoutrackSetup);
            youtrackApi.Start();
        }

        private void InitializeYoutrackIssues(int youtrackIssuesCount)
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
            FillPage(0);
        }

        private void FillPage(int pageCount)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                for (int i = 0; i < 3; i++)
                {
                    var issueCount = (pageCount * 3) + i;
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

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            pageCounter = Math.Max((pageCounter - 1), 0);
            FillPage(pageCounter);
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            pageCounter++;
            FillPage(pageCounter);
        }
    }
}
