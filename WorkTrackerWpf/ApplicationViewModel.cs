using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WorkTrackerWpf.Utilities;
using WorkTrackerWpf.ViewModels;

namespace WorkTrackerWpf
{
    public class ApplicationViewModel : ObservableObject
    {
        private ICommand changePageCommand;
        public ICommand ChangePageCommand
        {
            get
            {
                if (changePageCommand == null)
                {
                    changePageCommand = new DelegateCommand(
                        x => ChangeViewModel((IPageViewModel)x),
                        x => x is IPageViewModel);
                }

                return changePageCommand;
            }
        }


        private List<IPageViewModel> pageViewModels;
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                {
                    pageViewModels = new List<IPageViewModel>();
                }

                return pageViewModels;
            }
        }

        private IPageViewModel currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public ApplicationViewModel()
        {
            // Add avaliable pages
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new YoutrackIssueCreationViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!pageViewModels.Contains(viewModel))
            {
                pageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels.FirstOrDefault(x => x == viewModel);
        }
    }
}
