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
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Ink;

namespace MyWindowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point currentPoint;
        private StylusPoint newStylusPoint;
        float size = 10;
        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Bruh(object sender, System.Windows.Input.StylusEventArgs e)
        {
            if (e.StylusDevice.InAir) {
                Line line = new Line();
                line.Stroke = SystemColors.WindowBrush;// Color.FromArgb(0, 128, 128, 128));
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                //line.Width = e.StylusDevice.ActiveSource.;

                currentPoint = e.GetPosition(this);

                MainCanvas.Children.Add(line);
            }
        }



        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed /*se.StylusDevice. == Stylus.StylusDown*/ )
            {
                Line line = new Line();
                line.Stroke = new DrawingBrush();// Color.FromArgb(0, 128, 128, 128));
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                
                currentPoint = e.GetPosition(this);

                MainCanvas.Children.Add(line);
            }
        }

        private void Clear(object sender, RoutedEventArgs e) 
        {
            MainCanvas.Children.Clear();
        }

        public MainWindow()
        {
            StylusPointDescription newDescription =
                new StylusPointDescription(new StylusPointPropertyInfo[]
                    {
                        new StylusPointPropertyInfo(StylusPointProperties.X),
                        new StylusPointPropertyInfo(StylusPointProperties.Y),
                        new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                        new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation),
                        new StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation),
                        new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                    });

            int[] propertyValues = { 1800, 1000, 1 };

            newStylusPoint = new StylusPoint(100, 100, .5f, newDescription, propertyValues);

            Title = "Лики это пиздец";

            InitializeComponent();
        }
    }
}
