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

namespace WorkTracker
{
    /// <summary>
    /// Interaction logic for AddWorkPage.xaml
    /// </summary>
    public partial class AddWorkPage : Page
    {
        public AddWorkPage()
        {
            InitializeComponent();
        }

        public AddWorkPage(object data)
            : this()
        {
            this.DataContext = data;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
