using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

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

        #region Zadanie 3

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
            Point1 = e.GetPosition((UIElement)sender); ;

        }

        private void Canva3MouseUp(object sender, MouseButtonEventArgs e)
        {

            Point2 = e.GetPosition((UIElement)sender); ;

            if (!LineButton3.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X,
                    Y1 = Point1.Y,
                    X2 = Point2.X,
                    Y2 = Point2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                MyCanvas3.Children.Add(line);

            }
            else if (!RectangleButton3.IsEnabled)
            {
                Rectangle rect = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(rect, minX);
                Canvas.SetTop(rect, minY);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

                MyCanvas3.Children.Add(rect);

            }
            else if (!CircleButton3.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(ellipse, minX);
                Canvas.SetTop(ellipse, minY);


                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                MyCanvas3.Children.Add(ellipse);
            }
        }
        #endregion

        #region Zadanie4

        private void LineButtonClicked4(object sender, RoutedEventArgs e)
        {
            LineButton4.IsEnabled = false;
            RectangleButton4.IsEnabled = true;
            CircleButton4.IsEnabled = true;
            MoveButton4.IsEnabled = true;

        }

        private void RectangleButtonClicked4(object sender, RoutedEventArgs e)
        {
            LineButton4.IsEnabled = true;
            RectangleButton4.IsEnabled = false;
            CircleButton4.IsEnabled = true;
            MoveButton4.IsEnabled = true;

        }

        private void CircleButtonClicked4(object sender, RoutedEventArgs e)
        {
            LineButton4.IsEnabled = true;
            RectangleButton4.IsEnabled = true;
            CircleButton4.IsEnabled = false;
            MoveButton4.IsEnabled = true;
        }

        private void MoveButtonClicked4(object sender, RoutedEventArgs e)
        {
            LineButton4.IsEnabled = true;
            RectangleButton4.IsEnabled = true;
            CircleButton4.IsEnabled = true;
            MoveButton4.IsEnabled = false;
        }


        Rectangle selectedRectangle;
        Line selectedLine;
        Ellipse selectedElipse;

        private void Canva4MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point2 = e.GetPosition((UIElement)sender);

            if (!LineButton4.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X,
                    Y1 = Point1.Y,
                    X2 = Point2.X,
                    Y2 = Point2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };


                MyCanvas4.Children.Add(line);

            }
            else if (!RectangleButton4.IsEnabled)
            {
                Rectangle rect = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(rect, minX);
                Canvas.SetTop(rect, minY);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

                MyCanvas4.Children.Add(rect);

            }
            else if (!CircleButton4.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(ellipse, minX);
                Canvas.SetTop(ellipse, minY);


                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                MyCanvas4.Children.Add(ellipse);
            }

            if (!MoveButton4.IsEnabled)
            {
                if (selectedRectangle != null)
                {
                    Canvas.SetLeft(selectedRectangle, Point2.X);
                    Canvas.SetTop(selectedRectangle, Point2.Y);
                }
                if (selectedElipse != null)
                {
                    Canvas.SetLeft(selectedElipse, Point2.X);
                    Canvas.SetTop(selectedElipse, Point2.Y);
                }
                if (selectedLine != null)
                {
                    double minX = Math.Min(selectedLine.X1, selectedLine.X2);
                    double minY = Math.Min(selectedLine.Y1, selectedLine.Y2);
                    double maxX = Math.Max(selectedLine.X1, selectedLine.X2);
                    double maxY = Math.Max(selectedLine.Y1, selectedLine.Y2);

                    double oldX = selectedLine.X1;
                    double oldY = selectedLine.Y1;

                    selectedLine.X1 = Point2.X;
                    selectedLine.Y1 = Point2.Y;

                    selectedLine.X2 = selectedLine.X2 + (selectedLine.X1 - oldX);
                    selectedLine.Y2 = selectedLine.Y2 + (selectedLine.Y1 - oldY);

                }
            }

        }

        private void Canva4MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point1 = e.GetPosition((UIElement)sender);

            if (!MoveButton4.IsEnabled)
            {
                if (e.OriginalSource is Rectangle)
                {
                    selectedRectangle = (Rectangle)e.OriginalSource;
                    selectedElipse = new();
                    selectedLine = new();
                }
                else if (e.OriginalSource is Line)
                {
                    selectedLine = (Line)e.OriginalSource;
                    selectedRectangle = new();
                    selectedElipse = new();

                }
                else if (e.OriginalSource is Ellipse)
                {
                    selectedElipse = (Ellipse)e.OriginalSource;
                    selectedLine = new();
                    selectedRectangle = new();

                }

            }

        }
        #endregion

        #region Zadanie5

        private void LineButtonClicked5(object sender, RoutedEventArgs e)
        {
            LineButton5.IsEnabled = false;
            RectangleButton5.IsEnabled = true;
            CircleButton5.IsEnabled = true;
            TransformButton5.IsEnabled = true;
        }

        private void RectangleButtonClicked5(object sender, RoutedEventArgs e)
        {
            LineButton5.IsEnabled = true;
            RectangleButton5.IsEnabled = false;
            CircleButton5.IsEnabled = true;
            TransformButton5.IsEnabled = true;
        }

        private void CircleButtonClicked5(object sender, RoutedEventArgs e)
        {
            LineButton5.IsEnabled = true;
            RectangleButton5.IsEnabled = true;
            CircleButton5.IsEnabled = false;
            TransformButton5.IsEnabled = true;

        }

        private void TransformButtonClicked5(object sender, RoutedEventArgs e)
        {
            TransformButton5.IsEnabled = false;
            LineButton5.IsEnabled = true;
            RectangleButton5.IsEnabled = true;
            CircleButton5.IsEnabled = true;
        }

        private void Canva5MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point1 = e.GetPosition((UIElement)sender);

            if (!TransformButton5.IsEnabled)
            {
                if (e.OriginalSource is Rectangle)
                {
                    selectedRectangle = (Rectangle)e.OriginalSource;
                    selectedElipse = new();
                    selectedLine = new();
                }
                else if (e.OriginalSource is Line)
                {
                    selectedLine = (Line)e.OriginalSource;
                    selectedRectangle = new();
                    selectedElipse = new();

                }
                else if (e.OriginalSource is Ellipse)
                {
                    selectedElipse = (Ellipse)e.OriginalSource;
                    selectedLine = new();
                    selectedRectangle = new();

                }

            }
        }

        private void Canva5MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point2 = e.GetPosition((UIElement)sender);

            if (!LineButton5.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X,
                    Y1 = Point1.Y,
                    X2 = Point2.X,
                    Y2 = Point2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };


                MyCanvas5.Children.Add(line);

            }
            else if (!RectangleButton5.IsEnabled)
            {
                Rectangle rect = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(rect, minX);
                Canvas.SetTop(rect, minY);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

                MyCanvas5.Children.Add(rect);

            }
            else if (!CircleButton5.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(ellipse, minX);
                Canvas.SetTop(ellipse, minY);


                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                MyCanvas5.Children.Add(ellipse);
            }

            if (!TransformButton5.IsEnabled)
            {
                if (selectedRectangle != null)
                {
                    if (Point2.X - Canvas.GetLeft(selectedRectangle) > 0 && Point2.Y - Canvas.GetTop(selectedRectangle) > 0)
                    {
                        selectedRectangle.Width = Point2.X - Canvas.GetLeft(selectedRectangle);
                        selectedRectangle.Height = Point2.Y - Canvas.GetTop(selectedRectangle);
                    }
                }
                if (selectedElipse != null)
                {
                    if (Point2.X - Canvas.GetLeft(selectedElipse) > 0 && Point2.Y - Canvas.GetTop(selectedElipse) > 0)
                    {
                        selectedElipse.Width = Point2.X - Canvas.GetLeft(selectedElipse);
                        selectedElipse.Height = Point2.Y - Canvas.GetTop(selectedElipse);
                    }
                }
                if (selectedLine != null)
                {
                    selectedLine.X2 = Point2.X;
                    selectedLine.Y2 = Point2.Y;
                }
            }
        }
        #endregion

        #region Zadanie 6

        private void LineButtonClicked6(object sender, RoutedEventArgs e)
        {
            LineButton6.IsEnabled = false;
            RectangleButton6.IsEnabled = true;
            CircleButton6.IsEnabled = true;
            TransformButton6.IsEnabled = true;
            XStart6.Text = "";
            XEnd6.Text = "";
            YStart6.Text = "";
            YEnd6.Text = "";

        }

        private void RectangleButtonClicked6(object sender, RoutedEventArgs e)
        {
            LineButton6.IsEnabled = true;
            RectangleButton6.IsEnabled = false;
            CircleButton6.IsEnabled = true;
            TransformButton6.IsEnabled = true;
            WidthText6.Text = "";
            HeightText6.Text = "";
        }

        private void CircleButtonClicked6(object sender, RoutedEventArgs e)
        {
            LineButton6.IsEnabled = true;
            RectangleButton6.IsEnabled = true;
            CircleButton6.IsEnabled = false;
            TransformButton6.IsEnabled = true;
            RadiusText6.Text = "";

        }

        private void TransformButtonClicked6(object sender, RoutedEventArgs e)
        {
            TransformButton6.IsEnabled = false;
            LineButton6.IsEnabled = true;
            RectangleButton6.IsEnabled = true;
            CircleButton6.IsEnabled = true;
        }

        private void Canva6MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point1 = e.GetPosition((UIElement)sender);

            if (!TransformButton6.IsEnabled)
            {
                if (e.OriginalSource is Rectangle)
                {
                    WidthText6.Text = "";
                    HeightText6.Text = "";

                    selectedRectangle = (Rectangle)e.OriginalSource;
                    selectedElipse = new();
                    selectedLine = new();

                    WidthText6.Text = selectedRectangle.Width.ToString();
                    HeightText6.Text = selectedRectangle.Height.ToString();
                }
                else if (e.OriginalSource is Line)
                {
                    XStart6.Text = "";
                    XEnd6.Text = "";
                    YStart6.Text = "";
                    YEnd6.Text = "";

                    selectedLine = (Line)e.OriginalSource;
                    selectedRectangle = new();
                    selectedElipse = new();

                    XStart6.Text = selectedLine.X1.ToString();
                    XEnd6.Text = selectedLine.X2.ToString();
                    YStart6.Text = selectedLine.Y1.ToString();
                    YEnd6.Text = selectedLine.Y2.ToString();

                }
                else if (e.OriginalSource is Ellipse)
                {
                    RadiusText6.Text = "";

                    selectedElipse = (Ellipse)e.OriginalSource;
                    selectedLine = new();
                    selectedRectangle = new();

                    RadiusText6.Text = selectedElipse.Width.ToString();
                }

            }
        }

        private void Canva6MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point2 = e.GetPosition((UIElement)sender);

            if (!LineButton6.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X,
                    Y1 = Point1.Y,
                    X2 = Point2.X,
                    Y2 = Point2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };


                MyCanvas6.Children.Add(line);

            }
            else if (!RectangleButton6.IsEnabled)
            {
                Rectangle rect = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(rect, minX);
                Canvas.SetTop(rect, minY);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

                MyCanvas6.Children.Add(rect);

            }
            else if (!CircleButton6.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(ellipse, minX);
                Canvas.SetTop(ellipse, minY);


                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                MyCanvas6.Children.Add(ellipse);
            }

        }


        private void TextChanged6(object sender, TextChangedEventArgs e)
        {
            if (!TransformButton6.IsEnabled)
            {
                if (selectedRectangle!=null && WidthText6.Text != "" && HeightText6.Text!="")
                {
                    selectedRectangle.Width = Convert.ToDouble(WidthText6.Text);
                    selectedRectangle.Height = Convert.ToDouble(HeightText6.Text);
                }

                if (selectedElipse != null && RadiusText6.Text != "")
                {
                    selectedElipse.Width = Convert.ToDouble(RadiusText6.Text);
                    selectedElipse.Height = Convert.ToDouble(RadiusText6.Text);
                }

                if (selectedLine != null && XStart6.Text != "" && YStart6.Text != "" && XEnd6.Text != "" && YEnd6.Text != "")
                {
                    selectedLine.X1 = Convert.ToDouble(XStart6.Text);
                    selectedLine.X2 = Convert.ToDouble(XEnd6.Text);
                    selectedLine.Y1 = Convert.ToDouble(YStart6.Text);
                    selectedLine.Y2 = Convert.ToDouble(YEnd6.Text);
                }
            }

        }
        #endregion


        #region Zadanie 7

        Shape selectedShape;
        private void LineButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = false;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = true;
            SelectButton7.IsEnabled = true;

        }

        private void RectangleButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = false;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = true;
            SelectButton7.IsEnabled = true;

        }

        private void CircleButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = false;
            MoveButton7.IsEnabled = true;
            SelectButton7.IsEnabled = true;
        }

        private void MoveButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = false;
            SelectButton7.IsEnabled = true;
        }



        private void SaveButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = true;

            SelectButton7.IsEnabled = true;

            SaveFileDialog fileDialog = new()
            {
                Filter = "XML File | *.xml"
            };

            bool? result = fileDialog.ShowDialog();

            if (result is not true)
                return;

            string fileName = fileDialog.FileName;
            if (selectedShape!=null)
            {
                string xml = XamlWriter.Save(selectedShape);

                using StreamWriter writer = new(fileName, false);
                writer.Write(xml);
            }



        }

        private void LoadButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = true;

            OpenFileDialog dialog = new()
            {
                Filter = "XML File | *.xml"
            };
            ;
            bool? result = dialog.ShowDialog();

            if (result is not true) return;

            string fileName = dialog.FileName;

            using FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read);
            Object reader = XamlReader.Load(fs);

            MyCanvas7.Children.Add((UIElement)reader);
        }

        private void SelectButtonClicked7(object sender, RoutedEventArgs e)
        {
            LineButton7.IsEnabled = true;
            RectangleButton7.IsEnabled = true;
            CircleButton7.IsEnabled = true;
            MoveButton7.IsEnabled = true;
            SelectButton7.IsEnabled = false;
        }

        private void Canva7MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point2 = e.GetPosition((UIElement)sender);

            if (!LineButton7.IsEnabled)
            {
                Line line = new()
                {
                    X1 = Point1.X,
                    Y1 = Point1.Y,
                    X2 = Point2.X,
                    Y2 = Point2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };


                MyCanvas7.Children.Add(line);

            }
            else if (!RectangleButton7.IsEnabled)
            {
                Rectangle rect = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(rect, minX);
                Canvas.SetTop(rect, minY);

                double height = maxY - minY;
                double width = maxX - minX;

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

                MyCanvas7.Children.Add(rect);

            }
            else if (!CircleButton7.IsEnabled)
            {
                Ellipse ellipse = new()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                double minX = Math.Min(Point1.X, Point2.X);
                double minY = Math.Min(Point1.Y, Point2.Y);
                double maxX = Math.Max(Point1.X, Point2.X);
                double maxY = Math.Max(Point1.Y, Point2.Y);

                Canvas.SetLeft(ellipse, minX);
                Canvas.SetTop(ellipse, minY);


                double height = maxY - minY;
                double width = maxX - minX;

                ellipse.Height = Math.Abs(height);
                ellipse.Width = Math.Abs(width);

                MyCanvas7.Children.Add(ellipse);
            }

            if (!MoveButton7.IsEnabled)
            {
                if (selectedRectangle != null)
                {
                    Canvas.SetLeft(selectedRectangle, Point2.X);
                    Canvas.SetTop(selectedRectangle, Point2.Y);
                }
                if (selectedElipse != null)
                {
                    Canvas.SetLeft(selectedElipse, Point2.X);
                    Canvas.SetTop(selectedElipse, Point2.Y);
                }
                if (selectedLine != null)
                {
                    double minX = Math.Min(selectedLine.X1, selectedLine.X2);
                    double minY = Math.Min(selectedLine.Y1, selectedLine.Y2);
                    double maxX = Math.Max(selectedLine.X1, selectedLine.X2);
                    double maxY = Math.Max(selectedLine.Y1, selectedLine.Y2);

                    double oldX = selectedLine.X1;
                    double oldY = selectedLine.Y1;

                    selectedLine.X1 = Point2.X;
                    selectedLine.Y1 = Point2.Y;

                    selectedLine.X2 = selectedLine.X2 + (selectedLine.X1 - oldX);
                    selectedLine.Y2 = selectedLine.Y2 + (selectedLine.Y1 - oldY);

                }
            }

        }

        private void Canva7MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point1 = e.GetPosition((UIElement)sender);

            if (!SelectButton7.IsEnabled)
            {
                selectedShape = (Shape)e.OriginalSource;
            }

            if (!MoveButton7.IsEnabled)
            {
                if (e.OriginalSource is Rectangle)
                {
                    GetSelectedFigure((Rectangle)e.OriginalSource);
                    selectedRectangle = (Rectangle)e.OriginalSource;
                    selectedElipse = new();
                    selectedLine = new();

                }
                else if (e.OriginalSource is Line)
                {
                    GetSelectedFigure((Line)e.OriginalSource);
                    selectedLine = (Line)e.OriginalSource;
                    selectedElipse = new();
                    selectedRectangle = new();
                }
                else if (e.OriginalSource is Ellipse)
                {
                    GetSelectedFigure((Ellipse)e.OriginalSource);
                    selectedElipse = (Ellipse)e.OriginalSource;
                    selectedRectangle = new();
                    selectedLine = new();
                }

            }

        }

        private void GetSelectedFigure(Shape figure)
        {
            if(!SelectButton7.IsEnabled)
            {
                selectedShape = figure;
            }
        }

        #endregion

        
    }
}

