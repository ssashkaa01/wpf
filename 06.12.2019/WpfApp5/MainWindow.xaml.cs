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
using System.Windows.Threading;

namespace WpfApp5
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timerVideoTime;

        public MainWindow()
        {
            InitializeComponent();
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
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
                timerVideoTime.Start();
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
           
            TopPlayer.Pause();
            timerVideoTime.Stop();
        }

        private void TopPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            timelineSlider.Maximum = TopPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            timelineSlider.Value = 0;
            TopPlayer.Play();
        }

        private void TimerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //TopPlayer.Pause();
            //TopPlayer.Position = TimeSpan.FromSeconds(timelineSlider.Value);
            //TopPlayer.Play();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            TopPlayer.Pause();
            TopPlayer.Position = TopPlayer.Position - TimeSpan.FromSeconds(1);
            TopPlayer.Play();
            
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            TopPlayer.Pause();
            TopPlayer.Position = TopPlayer.Position + TimeSpan.FromSeconds(1);
            TopPlayer.Play();
        }

        void timer_Tick(object sender, EventArgs e)
        {
           
            timelineSlider.Value = TopPlayer.Position.Seconds;

            timelineSlider.SelectionEnd = TopPlayer.Position.Seconds;

        }
    }
}
