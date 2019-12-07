using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        bool CapsSet { get; set; }
        public object Keys { get; }

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        
        public MainWindow()
        {

            InitializeComponent();
            ReverseCharKeyBoard();


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
            btnReset.IsEnabled = true;
            countSeconds = 0;
            countErrors = 0;
            UpdateStatusBar();
            dispatcherTimer.Start();
            textBox1.Text = GetTrainingText();
            progressBar.Maximum = textBox1.Text.Length;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage();
            ResetAll();
        }

        private void UpdateStatusBar()
        {
            statusBar.Content = $"Errors: {countErrors} :: Timer {countSeconds} sec";
        }

        private bool IsNumber(string key)
        {
            Regex test = new Regex("^[D][0-9]{1}$");

            return test.IsMatch(key);
        }

        private bool IsCapsLock(string key)
        {
            return key == "Capital" || key == "Caps Lock";
        }

        private bool IsAlt(string key)
        {
            return key == "System";
        }
        
        private bool IsWin(string key)
        {
            return key == "Win";
        }

        private bool IsSpace(string key)
        {
            return key == "Space";
        }

        private bool IsCtrl(string key)
        {
            Regex test = new Regex("Ctrl");

            return test.IsMatch(key);
        }

        private bool IsBigChar(string key)
        {
            Regex test = new Regex("^[A-Z]$");

            return test.IsMatch(key);
        }
        private bool IsLittleChar(string key)
        {
            Regex test = new Regex("^[a-z]$");

            return test.IsMatch(key);
        }

        private bool IsShift(string key)
        {
            Regex test = new Regex("Shift");

            return test.IsMatch(key);
        }

        private string ReverseChar(string key)
        {
            if(IsLittleChar(key))
            {
                return key.ToUpper();
            }
            else if(IsBigChar(key))
            {
                return key.ToLower();
            }
            else
            {
                return key;
            }
        }

        private void ReverseCharKeyBoard()
        {
            foreach (var item in buttons.Children)
            {
                if (item is Border)
                {
                    if (((Border)item).Child is TextBlock)
                    {
                        ((TextBlock)((Border)item).Child).Text = ReverseChar(((TextBlock)((Border)item).Child).Text);
                    }
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string key = Convert.ToString(e.Key);

            if (IsCapsLock(key))
            {
                key = "Caps Lock";
                ReverseCharKeyBoard();
            }

            else if (IsAlt(key))
            {
                key = "Alt";
            }

            else if (IsWin(key))
            {
                key = "Win";
            }

            else if (IsCtrl(key) || IsSpace(key) || IsShift(key))
            {

            }

            else
            {
                key = Convert.ToString(GetCharFromKey(e.Key));
            }

            foreach (var item in buttons.Children)
            {
                
                if(item is Border)
                {
                    if(((Border)item).Child is TextBlock && ((TextBlock)((Border)item).Child).Text == key)
                    {
                        ((Border)item).Background = ((Border)item).BorderBrush;
                    }
                }
            }
        }

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
            btnStart.IsEnabled = true;
            dispatcherTimer.Stop();
            UpdateStatusBar();
            progressBar.Value = 0;
        }

        private string GetTrainingText()
        {
            return "But I must explain to you how all.";
        }

        private bool CheckKeyInText(char key)
        {
            if (textBox1.Text != "")
            {
                return key == textBox1.Text[0];
            }
            else
            {
                return false;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string key = Convert.ToString(e.Key);

            if (IsCapsLock(key))
            {
                key = "Caps Lock";
            }

            else if (IsAlt(key))
            {
                key = "Alt";
            }

            else if (IsWin(key))
            {
                key = "Win";
            }

            else if (IsCtrl(key) || IsSpace(key) || IsShift(key))
            {

            }

            else
            {
                key = Convert.ToString(GetCharFromKey(e.Key));
            }

            foreach (var item in buttons.Children)
            {

                if (item is Border)
                {
                    if (((Border)item).Child is TextBlock && ((TextBlock)((Border)item).Child).Text == key)
                    {
                        ((Border)item).Background = null;
                    }
                }
            }

            if (CheckKeyInText(GetCharFromKey(e.Key)))
            {
                textBox2.Text += GetCharFromKey(e.Key);
                textBox1.Text = textBox1.Text.Substring(1);
                progressBar.Value = textBox2.Text.Length;

                

            }
            else if(!IsCapsLock(key) && !IsShift(key))
            {
                
                countErrors++;
                UpdateStatusBar();
            }

            if (textBox1.Text.Length == 0 && btnStart.IsEnabled == false)
            {
                ShowMessage();
                ResetAll();
            }
        }

        public enum MapType : uint
        {
            MAPVK_VK_TO_VSC = 0x0,
            MAPVK_VSC_TO_VK = 0x1,
            MAPVK_VK_TO_CHAR = 0x2,
            MAPVK_VSC_TO_VK_EX = 0x3,
        }

        [DllImport("user32.dll")]
        public static extern int ToUnicode(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 4)]
            StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags);

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, MapType uMapType);

        public static char GetCharFromKey(Key key)
        {
            char ch = ' ';

            int virtualKey = KeyInterop.VirtualKeyFromKey(key);
            byte[] keyboardState = new byte[256];
            GetKeyboardState(keyboardState);

            uint scanCode = MapVirtualKey((uint)virtualKey, MapType.MAPVK_VK_TO_VSC);
            StringBuilder stringBuilder = new StringBuilder(2);

            int result = ToUnicode((uint)virtualKey, scanCode, keyboardState, stringBuilder, stringBuilder.Capacity, 0);
            switch (result)
            {
                case -1:
                    break;
                case 0:
                    break;
                case 1:
                    {
                        ch = stringBuilder[0];
                        break;
                    }
                default:
                    {
                        ch = stringBuilder[0];
                        break;
                    }
            }
            return ch;
        }
    }
}
