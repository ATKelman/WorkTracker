using System.Windows;
using WorkTracker.Pages;

namespace WorkTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new MainPage();
        }

        private void changePage_CreateNewCase(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CreateNewCaseView();
        }

        private void changePage_EditCase(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TimeReportPage();
        }

        private void changePage_ViewSummary(object sender, RoutedEventArgs e)
        {
            // TODO make width and height of youtrack issue be decided by page size, buttons take 1* each while issues take 3* each
            MainContent.Content = new ViewSummaryPage(3, 180, 300);
        }

        private void changePage_MainPage(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MainPage();
        }
    }
}
