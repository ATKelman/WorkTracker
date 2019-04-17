using System.Windows.Controls;
using Youtrack;

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
            youtrack = new Youtrack.Youtrack();
            RetrieveIssue();
        }

        // Retrieve Information 
        public void RetrieveIssue()
        {
            var issue = youtrack.GetIssue("OTHER-5");
        }
    }
}
