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
using System.Windows.Threading;

namespace Keyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        int countErrors { get; set; }
        int countSeconds { get; set; }

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            UpdateStatusBar();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            countSeconds++;
            UpdateStatusBar();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            countSeconds = 0;
            countErrors = 0;
            UpdateStatusBar();
            dispatcherTimer.Start();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = true;
            dispatcherTimer.Stop();
        }

        private void UpdateStatusBar()
        {
            statusBar.Content = $"Errors: {countErrors} :: Timer {countSeconds} sec";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach(var item in buttons.Children)
            {
                
                if(item is Border)
                {
                    
                   // MessageBox.Show("1");
                    //if((item is Border))
                }


            }
            //MessageBox.Show($"{e.Key}");
        }



        /*

        
        private void ShowMessage()
        {
            MessageBox.Show($"Errors: {countErrors} :: Time {countSeconds} sec", "Result");
        }

        private void ResetAll()
        {
            countErrors = 0;
            countSeconds = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            buttonStart.Enabled = true;
            timer1.Stop();
            UpdateStatusBar();
            progressBar.Value = 0;

        }

        private string GetTrainingText()
        {
            return "But I must explain to you how all.";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ResetAll();
            buttonStart.Enabled = false;
            timer1.Start();
            textBox1.Text = GetTrainingText();
            progressBar.Maximum = textBox1.Text.Length;

        }

        private bool CheckKeyInText(char key)
        {
            if (textBox1.Text != "")
            {
                return key == textBox1.Text[0];
            }
            else
            {
                ShowMessage();
                ResetAll();
                return false;
            }
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckKeyInText(e.KeyChar))
            {
                textBox2.Text += e.KeyChar;
                textBox1.Text = textBox1.Text.Substring(1);
                progressBar.Value = textBox2.Text.Length;

            }
            else
            {
                countErrors++;
                UpdateStatusBar();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countSeconds++;
            UpdateStatusBar();
        }

    */

    }
}
