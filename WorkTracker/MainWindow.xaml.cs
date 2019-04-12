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

        }

        private void changePage_ViewSummary(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ViewSummaryPage();
        }

        private void changePage_MainPage(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MainPage();
        }
    }
}
