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
    }
}
