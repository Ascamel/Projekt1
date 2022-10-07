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

namespace Projekt1
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

        private void LineButtonClicked(object sender, RoutedEventArgs e)
        {
            Line line = new()
            {
                X1 = 10,
                Y1 = 10,

                X2 = 200,
                Y2 = 200,

                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            MyCanvas.Children.Add(line);
        }

        private void RectangleButtonClicked(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new()
            {
                Width = 200,
                Height = 50,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            MyCanvas.Children.Add(rectangle);
        }

        private void CircleButtonClicked(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = new()
            {
                Width = 50,
                Height = 50,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            MyCanvas.Children.Add(ellipse);
        }

        private void Line2ButtonClicked(object sender, RoutedEventArgs e)
        {
            LineButton2.IsEnabled = false;
            RectangleButton2.IsEnabled = true;
            CircleButton2.IsEnabled = true;
        }

        private void Rectangle2ButtonClicked(object sender, RoutedEventArgs e)
        {
            LineButton2.IsEnabled = true;
            RectangleButton2.IsEnabled = false;
            CircleButton2.IsEnabled = true;
        }

        private void Circle2ButtonClicked(object sender, RoutedEventArgs e)
        {
            LineButton2.IsEnabled = true;
            RectangleButton2.IsEnabled = true;
            CircleButton2.IsEnabled = false;
        }

        private void Draw2Button_Click(object sender, RoutedEventArgs e)
        {
            if (!LineButton2.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Convert.ToDouble(XStart.Text),
                    Y1 = Convert.ToDouble(YStart.Text),

                    X2 = Convert.ToDouble(XEnd.Text),
                    Y2 = Convert.ToDouble(YEnd.Text),

                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                MyCanvas2.Children.Add(line);
            }
            else if(!RectangleButton2.IsEnabled)
            {

                Rectangle rectangle = new()
                {
                    Width = Convert.ToDouble(WithText.Text),
                    Height =  Convert.ToDouble(HeightText.Text),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                MyCanvas2.Children.Add(rectangle);

            }
            else if(!CircleButton2.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Width = 2 * Convert.ToDouble(RadiusText.Text),
                    Height = 2 * Convert.ToDouble(RadiusText.Text),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                MyCanvas2.Children.Add(ellipse);

            }
        }
    }
}
