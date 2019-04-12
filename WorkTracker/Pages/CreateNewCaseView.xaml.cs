using System.Threading;
using System.Windows.Controls;

namespace WorkTracker.Pages
{
    public partial class CreateNewCaseView : Page
    {
        public CreateNewCaseView()
        {
            InitializeComponent();

            Thread youtrackApi = new Thread(ApiThread);
            youtrackApi.Start();
        }

        public void ApiThread()
        {
            var youtrack = new Youtrack.Youtrack();
            //var issue = youtrack.GetIssue("OTHER-5");
        }
    }
}
