using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                TopPlayer.Source = new Uri(openFileDialog.FileName);

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(TopPlayer.IsLoaded)
            {
                TopPlayer.Play();
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
           
            TopPlayer.Pause();
        }

       
    }
}
