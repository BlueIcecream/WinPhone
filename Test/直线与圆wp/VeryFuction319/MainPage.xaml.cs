using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VeryFuction319.Resources;
using System.Windows.Shapes;
using System.Windows.Media;

namespace VeryFuction319
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            //Ellipse
            //Line l = new Line { X1 = 0, X2 = 100, Y1 = 0,Y2=100 ,
            //    Stroke = new SolidColorBrush(Colors.Red), StrokeThickness=10};Canvas.Children.Add(l);
         

            Ellipse w = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Blue),
                StrokeThickness = 10
            };
            w.SetValue(Canvas.LeftProperty, 65.00);
            w.SetValue(Canvas.TopProperty, 70.00);
            Canvas.Children.Add(w);

            Ellipse e = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 10
            };
            e.SetValue(Canvas.LeftProperty, 175.00);
            e.SetValue(Canvas.TopProperty, 70.00);
            Canvas.Children.Add(e);

            Ellipse r = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 10
            };
            r.SetValue(Canvas.LeftProperty, 55.00);
            r.SetValue(Canvas.TopProperty, 380.00);
            Canvas.Children.Add(r);

            Ellipse t = new Ellipse
            {
                Width = 20,
                Height = 20,
                Stroke = new SolidColorBrush(Colors.Green),
                StrokeThickness = 10
            };
            t.SetValue(Canvas.LeftProperty, 140.00);
            t.SetValue(Canvas.TopProperty, 380.00);
            Canvas.Children.Add(t);
        }
    }
}