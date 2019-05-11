using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTrackerWpf.Utilities;

namespace WorkTrackerWpf.ViewModels
{
    public class YoutrackIssueCreationViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "YoutrackIssueCreation Page";
            }
        }
    }
}
