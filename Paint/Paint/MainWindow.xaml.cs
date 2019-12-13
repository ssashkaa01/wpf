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

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point startPoint = new Point();
        Point endPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint.X = e.GetPosition(Background).X;
            startPoint.Y = e.GetPosition(Background).Y;
        }

        private void Background_MouseUp(object sender, MouseButtonEventArgs e)
        {
            endPoint.X = e.GetPosition(Background).X;
            endPoint.Y = e.GetPosition(Background).Y;
            
            PaintFigure();
        }

        // Малювання фігури
        private void PaintFigure()
        {

            // Лінія
            if (Line.IsChecked == true)
            {
                Line line = new Line();

                line.Stroke = GetColor();

                line.StrokeThickness = GetStrokeThickness();

                line.X1 = startPoint.X;
                line.Y1 = startPoint.Y;

                line.X2 = endPoint.X;
                line.Y2 = endPoint.Y;

                Background.Children.Add(line);
            }
            // Круг
            else if (Circle.IsChecked == true)
            {
                Ellipse circle = new Ellipse()
                {
                    Width = GetWidthFigure(),
                    Height = GetHeightFigure(),
                    Stroke = GetColor(),
                    StrokeThickness = GetStrokeThickness(),
                    
                };

                Background.Children.Add(circle);

                ConvertPoints();

                circle.SetValue(Canvas.LeftProperty, startPoint.X);
                circle.SetValue(Canvas.TopProperty, startPoint.Y);

            }

            // Прямокутник
            else if (Rectangle.IsChecked == true)
            {
                Rectangle rect = new Rectangle
                {
                    Width = GetWidthFigure(),
                    Height = GetHeightFigure(),
                    Stroke = GetColor(),
                    StrokeThickness = GetStrokeThickness(),
                };

                Background.Children.Add(rect);

                ConvertPoints();

                rect.SetValue(Canvas.LeftProperty, startPoint.X);
                rect.SetValue(Canvas.TopProperty, startPoint.Y); 
            }
        }

        // Отримання кольору
        private SolidColorBrush GetColor()
        {
            return new SolidColorBrush(Color.FromArgb(PaintColor.SelectedColor.Value.A, PaintColor.SelectedColor.Value.R, PaintColor.SelectedColor.Value.G, PaintColor.SelectedColor.Value.B));
        }

        // Отримання ширини
        private int GetStrokeThickness()
        {
            return 2;
        }

        // Конвертація координат
        private void ConvertPoints()
        {
            if (this.startPoint.X > this.endPoint.X)
            {
                this.startPoint.X = this.endPoint.X;
            }

            if (this.startPoint.Y > this.endPoint.Y)
            {
                this.startPoint.Y = this.endPoint.Y;
            }
        }

        // Отримання
        private double GetWidthFigure()
        {
            double newWidth = startPoint.X - endPoint.X;

            if (newWidth < 0)
            {
                newWidth *= -1;
            }

            return newWidth;
        }

        private double GetHeightFigure()
        {
           
            double newHeight = startPoint.Y - endPoint.Y;

            if (newHeight < 0)
            {
                newHeight *= -1;
            }

            return newHeight;
        }

        // Вибір фігур
        private void Figure_Checked(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox ch in Figures.Items)
            {
                if(ch != (CheckBox)sender)
                {
                    ch.IsChecked = false;
                }
            }
        }
    }
}
