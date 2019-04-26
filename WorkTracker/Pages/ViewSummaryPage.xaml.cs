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
                var element = new YoutrackIssue();
                element.HeaderLabel.Content = issue.Summary;
                element.DescriptionLabel.Content = issue.Description;

                element.MaxHeight = 350;
                element.MaxWidth = 180;

                SummaryGrid.Children.Add(element);
                Grid.SetColumn(element, 1);

                var element2 = new YoutrackIssue();
                element2.HeaderLabel.Content = issue.Summary;
                element2.DescriptionLabel.Content = issue.Description;

                element2.MaxHeight = 350;
                element2.MaxWidth = 180;

                SummaryGrid.Children.Add(element2);
                Grid.SetColumn(element2, 2);
            });         
        }
    }
}
