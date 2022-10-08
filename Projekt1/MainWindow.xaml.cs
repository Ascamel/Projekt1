using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
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

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

                if (line.X1 > line.X2)
                {
                    return;
                }

                if (line.Y1 > line.Y2)
                {
                    return;
                }

                MyCanvas2.Children.Add(line);
            }
            else if (!RectangleButton2.IsEnabled)
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
            else if (!CircleButton2.IsEnabled)
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

        Point Point1;
        Point Point2;

        private void LineButtonClicked3(object sender, RoutedEventArgs e)
        {
            LineButton3.IsEnabled = false;
            RectangleButton3.IsEnabled = true;
            CircleButton3.IsEnabled = true;

        }

        private void RectangleButtonClicked3(object sender, RoutedEventArgs e)
        {
            LineButton3.IsEnabled = true;
            RectangleButton3.IsEnabled = false;
            CircleButton3.IsEnabled = true;
        }

        private void CircleButtonClicked3(object sender, RoutedEventArgs e)
        {
            LineButton3.IsEnabled = true;
            RectangleButton3.IsEnabled = true;
            CircleButton3.IsEnabled = false;
        }

        private void Canva3MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point1 = e.GetPosition(this);

        }

        private void Canva3MouseUp(object sender, MouseButtonEventArgs e)
        {

            Point2 = e.GetPosition(this);

            if (!LineButton3.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X - 170,
                    Y1 = Point1.Y - 36,
                    X2 = Point2.X - 170,
                    Y2 = Point2.Y - 36,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                MyCanvas3.Children.Add(line);

            }
            else if (!RectangleButton3.IsEnabled)
            {
                Rectangle rect = new()
                {

                    Width = Math.Abs(Point1.X-Point2.X),
                    Height =  Math.Abs(Point1.Y-Point2.Y),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2

                };

                if (Point1.X < Point2.X)
                {
                    if (Point1.Y < Point2.Y)
                    {
                        Canvas.SetLeft(rect, Point1.X - 170);
                        Canvas.SetTop(rect, Point1.Y - 36);
                    }
                    else
                    {
                        Canvas.SetLeft(rect, Point1.X - 170);
                        Canvas.SetTop(rect, Point2.Y - 36);
                    }
                }
                else
                {
                    if (Point1.Y < Point2.Y)
                    {
                        Canvas.SetLeft(rect, Point2.X - 170);
                        Canvas.SetTop(rect, Point1.Y - 36);
                    }
                    else
                    {
                        Canvas.SetLeft(rect, Point2.X - 170);
                        Canvas.SetTop(rect, Point2.Y - 36);
                    }
                }

                MyCanvas3.Children.Add(rect);

            }
            else if (!CircleButton3.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Width = 2 * Math.Abs(Point1.X-Point2.X),
                    Height = 2 * Math.Abs(Point1.Y-Point2.Y),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                if (Point1.X < Point2.X)
                {
                    if (Point1.Y < Point2.Y)
                    {
                        Canvas.SetLeft(ellipse, Point1.X - 170);
                        Canvas.SetTop(ellipse, Point1.Y - 36);
                    }
                    else
                    {
                        Canvas.SetLeft(ellipse, Point1.X - 170);
                        Canvas.SetTop(ellipse, Point2.Y - 36);
                    }
                }
                else
                {
                    if (Point1.Y < Point2.Y)
                    {
                        Canvas.SetLeft(ellipse, Point2.X - 170);
                        Canvas.SetTop(ellipse, Point1.Y - 36);
                    }
                    else
                    {
                        Canvas.SetLeft(ellipse, Point2.X - 170);
                        Canvas.SetTop(ellipse, Point2.Y - 36);
                    }
                }
                MyCanvas3.Children.Add(ellipse);
            }

        }
    }
}

