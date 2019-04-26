using System.Threading;
using System.Windows.Controls;
using Youtrack;
using WorkTracker.UserControls;
using System.Windows;
using System;

namespace WorkTracker.Pages
{
    /// <summary>
    /// Interaction logic for ViewSummaryPage.xaml
    /// </summary>
    public partial class ViewSummaryPage : Page
    {
        private Youtrack.Youtrack youtrack;


        public ViewSummaryPage()
        {
            InitializeComponent();

            Thread youtrackApi = new Thread(ApiThread);
            //youtrackApi.SetApartmentState(ApartmentState.STA);
            youtrackApi.Start();
        }

        private void ApiThread()
        {
            youtrack = new Youtrack.Youtrack();
            RetrieveIssue();
        }

        // Retrieve Information 
        private void RetrieveIssue()
        {
            var issue = youtrack.GetIssue("OTHER-5");

            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                //var element = new TextBlock();
                //element.Text = issue.Summary;

                var element = new YoutrackIssue();
                element.HeaderLabel.Content = issue.Summary;
                element.DescriptionLabel.Content = issue.Description;

                IssuePanel.Children.Add(element);
            });         
        }
    }
}
