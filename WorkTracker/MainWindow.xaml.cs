using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        }

        private void changePage_MainPage(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MainPage();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Main.Content = new AddWorkPage();
        //}

        //private void Button2_Click(object sender, RoutedEventArgs e)
        //{
        //    Main.Content = new WorkTrackerHome();
        //}
    }
}
