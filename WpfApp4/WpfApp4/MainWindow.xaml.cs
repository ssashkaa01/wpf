using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string action { get; set; }
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if(stack.Children.Count > 0)
            {
                if(action == null)
                {
                    return;
                }

                this.stack.Children.Insert(0, new Label()
                {
                    Content = action
                });
            }

            this.stack.Children.Insert(0, new Label()
            {
                Content = number.Text.ToString()
            });
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            action = (sender as RadioButton).Content.ToString();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed((sender as TextBox).Text + e.Text);
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Text = "0";
            }
        }
    }
}
