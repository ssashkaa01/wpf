using SortGame.Models;
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

namespace SortGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SortModel sm = new SortModel();

        public MainWindow()
        {
            InitializeComponent();

            SortableNumbers.ItemsSource = sm.GetAllSortableNumbers();
            TmpNumbers.ItemsSource = sm.GetAllTmpNumbers();

        }

        private void BtnToTmp_Click(object sender, RoutedEventArgs e)
        {
            sm.MoveToTmp();
        }

        private void BtnToSortable_Click(object sender, RoutedEventArgs e)
        {
            sm.MoveToSortable();

            if(sm.CheckWin())
            {
                MessageBox.Show("YOU WIN!!!");
                sm.Restart();
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            sm.Restart();
        }
    }
}
