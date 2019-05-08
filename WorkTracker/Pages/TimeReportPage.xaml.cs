using System.Windows.Controls;

namespace WorkTracker.Pages
{
    public partial class TimeReportPage : Page
    {
        private string issueName;
        public string IssueName
        {
            get { return issueName; }
            set { issueName = value; }
        }

        private string timeSpent;
        public string TimeSpent
        {
            get { return timeSpent; }
            set { timeSpent = value; }
        }

        private string comments;
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public TimeReportPage()
        {
            InitializeComponent();
        }

        private void SubmitPressed(object sender, System.Windows.RoutedEventArgs e)
        {
            var test = "";
        }
    }
}
