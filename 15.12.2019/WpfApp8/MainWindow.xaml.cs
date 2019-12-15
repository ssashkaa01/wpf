using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<String> colors = new ObservableCollection<string>();

        RGB rgb = new RGB()
        {
            A = 0,
            R = 0,
            G = 0,
            B = 0
        };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this.rgb;

            listColors.ItemsSource = colors;
        }

        private bool IssetColor(string color)
        {
            return colors.FirstOrDefault(item => color == item) != null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!IssetColor(rgb.ColorName))
            {
                colors.Add(rgb.ColorName);
                btnAdd.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Колір вже існує.");
            }
        }

        private void Delete_Item(object sender, RoutedEventArgs e)
        {
            colors.Remove(Convert.ToString(((Button)sender).BorderBrush)); 
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IssetColor(rgb.ColorName))
            {
                btnAdd.IsEnabled = false;
            }
            else
            {
                btnAdd.IsEnabled = true;
            }
        }
    }

    class RGB : INotifyPropertyChanged
    {
        private byte a;
        private byte r;
        private byte g;
        private byte b;

        public byte A {
            get
            {
                return a;
            }

            set
            {
                a = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(a)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorName)));
            }
        }

        public byte R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(r)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorName)));
            }
        }

        public byte G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(g)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorName)));
            }
        }

        public byte B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(b)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ColorName)));
            }
        }

        public string ColorName
        {
            get
            {
                return Color.FromArgb(A, R, G, B).ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
