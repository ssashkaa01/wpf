using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Auth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //CultureInfo.CurrentUICulture = new CultureInfo("uk-UA", false);

            InitializeComponent();
            signIn.IsChecked = true;
        }

        private void SignIn_Checked(object sender, RoutedEventArgs e)
        {
            regFields.Visibility = Visibility.Hidden;
        }

        private void SignUp_Checked(object sender, RoutedEventArgs e)
        {
            regFields.Visibility = Visibility.Visible;
        }
    }
}
