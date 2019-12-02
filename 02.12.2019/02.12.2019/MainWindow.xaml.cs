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

namespace _02._12._2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDefaultData();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(countPassengers.Text);

            if(count > 7 || count < 0)
            {
                count = 0;
            }
       
            countPassengers.Text = $"{++count}";
        }

        private void CountPassengers_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SetDefaultData()
        {
            sendBtn.IsEnabled = false;
            inputName.Text = "";
            inputAddress.Text = "";
            countPassengers.Text = "0";
            agree.IsChecked = false;
            ClearCheckedtype();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            MessageBox.Show(pressed.Content.ToString());
        }

        private void CountPassengers_LostFocus(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(countPassengers.Text);

            if (count > 7 || count < 0)
            {
                count = 0;
            }

            countPassengers.Text = $"{count}";
        }

        private void Agree_Click(object sender, RoutedEventArgs e)
        {
            sendBtn.IsEnabled = Convert.ToBoolean(agree.IsChecked);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultData();
        }

        private void Agree_Checked(object sender, RoutedEventArgs e)
        {
            sendBtn.IsEnabled = true;
        }

        private void Agree_Unchecked(object sender, RoutedEventArgs e)
        {
            sendBtn.IsEnabled = false;
        }

        private string GetType()
        {
            string type = "";

            if(typeEconom.IsChecked == true)
            {
                type = typeEconom.Content.ToString();
            }
            else if(typeComfort.IsChecked == true)
            {
                type = typeEconom.Content.ToString();
            }
            else if (typeStandart.IsChecked == true)
            {
                type = typeEconom.Content.ToString();
            }

            return type;
        }

        private void ClearCheckedtype()
        {
            typeEconom.IsChecked = false;
            typeComfort.IsChecked = false;
            typeStandart.IsChecked = false;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            string content = $"Ім'я та прізвище: {inputName.Text}\nАдреса: {inputAddress.Text}\nКількість пасажирів: {countPassengers.Text}\nТип: {GetType()}";

            MessageBox.Show(content, "Інфо");
        }
    }
}
