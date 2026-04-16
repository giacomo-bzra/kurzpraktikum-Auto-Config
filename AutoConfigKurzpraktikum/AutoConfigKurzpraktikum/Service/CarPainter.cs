using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;

namespace AutoConfigKurzpraktikum.Service; 
    public static class CarPainter
    {
        public static void DrawOldtimer(Canvas targetCanvas){
            targetCanvas.Children.Clear();
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection { 
                new Point(30, 120), new Point(370,120), new Point(370, 80), new Point(340, 70), new Point(120, 70), new Point(30, 80)
            };
            MittelKörper.Fill = Brushes.SaddleBrown;
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 2;
            
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection { 
                new Point(100, 70), new Point(140,40), new Point(310,40), new Point(340, 70),
            };
            Fenster.Fill = Brushes.LightBlue;
            Fenster.Stroke = Brushes.Black;

            Polygon Spoler = new Polygon();
            Spoler.Points = new PointCollection
            {
                new Point(30, 75), new Point(60, 70),new Point(60, 76), new Point(64, 70), new Point(100, 65), new Point(100, 55), new Point(30, 65)             
            };
            Spoler.Fill = Brushes.Black;
            Spoler.Stroke = Brushes.Black;
            Spoler.StrokeThickness = 2;

            Ellipse Wheel1 = new Ellipse();
            Wheel1.Width = 60;
            Wheel1.Height = 60;
            Wheel1.Fill = Brushes.Silver;
            Wheel1.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel1, 70);
            Canvas.SetTop(Wheel1, 90);
            
            Ellipse Wheel2 = new Ellipse();
            Wheel2.Width = 60;
            Wheel2.Height = 60;
            Wheel2.Fill = Brushes.Silver;
            Wheel2.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel2, 270);
            Canvas.SetTop(Wheel2, 90);
            
            targetCanvas.Children.Add(Wheel1);
            targetCanvas.Children.Add(Wheel2);
            targetCanvas.Children.Add(MittelKörper);
            targetCanvas.Children.Add(Fenster);
            targetCanvas.Children.Add(Spoler);
        }
        public static void DrawOldtimerSmall(Canvas targetCanvas)
        {
            targetCanvas.Children.Clear();
            
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection { 
                new Point(15, 60), new Point(185, 60), new Point(185, 40), 
                new Point(170, 35), new Point(60, 35), new Point(15, 40)
            };
            MittelKörper.Fill = Brushes.SaddleBrown;
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 1;
            
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection { 
                new Point(50, 35), new Point(70, 20), new Point(155, 20), new Point(170, 35)
            };
            Fenster.Fill = Brushes.LightBlue;
            Fenster.Stroke = Brushes.Black;

            Polygon Spoler = new Polygon();
            Spoler.Points = new PointCollection
            {
                new Point(15, 37.5), new Point(30, 35), new Point(30, 38), 
                new Point(32, 35), new Point(50, 32.5), new Point(50, 27.5), new Point(15, 32.5)             
            };
            Spoler.Fill = Brushes.Black;
            Spoler.Stroke = Brushes.Black;
            Spoler.StrokeThickness = 1;
            
            Ellipse Wheel1 = new Ellipse();
            Wheel1.Width = 30;
            Wheel1.Height = 30;
            Wheel1.Fill = Brushes.Silver;
            Wheel1.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel1, 35);
            Canvas.SetTop(Wheel1, 45);
    
            Ellipse Wheel2 = new Ellipse();
            Wheel2.Width = 30;
            Wheel2.Height = 30;
            Wheel2.Fill = Brushes.Silver;
            Wheel2.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel2, 135);
            Canvas.SetTop(Wheel2, 45);
            
            targetCanvas.Children.Add(Wheel1);
            targetCanvas.Children.Add(Wheel2);
            targetCanvas.Children.Add(MittelKörper);
            targetCanvas.Children.Add(Fenster);
            targetCanvas.Children.Add(Spoler);
        }

        public static void DrawModernCar(Canvas targetCanvas)
        {
            targetCanvas.Children.Clear();
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection { 
                new Point(50, 120), new Point(350, 120), new Point(360, 110), 
                new Point(370, 80), new Point(340, 70), new Point(120, 70), new Point(60, 80) 
            };
            MittelKörper.Fill = Brushes.SteelBlue;
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 2;
            
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection { 
                new Point(130, 70), new Point(180, 30), new Point(260, 30), new Point(310, 70) 
            };
            Fenster.Fill = Brushes.LightBlue;
            Fenster.Stroke = Brushes.Black;

            Polygon Spoler = new Polygon();
            Spoler.Points = new PointCollection
            {
                new Point(55, 80), new Point(40, 50), new Point(80,75)
            };
            Spoler.Fill = Brushes.Black;
            Spoler.Stroke = Brushes.Black;
            Spoler.StrokeThickness = 2;

            Ellipse Wheel1 = new Ellipse();
            Wheel1.Width = 60;
            Wheel1.Height = 60;
            Wheel1.Fill = Brushes.Silver;
            Wheel1.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel1, 70);
            Canvas.SetTop(Wheel1, 90);
            
            Ellipse Wheel2 = new Ellipse();
            Wheel2.Width = 60;
            Wheel2.Height = 60;
            Wheel2.Fill = Brushes.Silver;
            Wheel2.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel2, 270);
            Canvas.SetTop(Wheel2, 90);
            
            targetCanvas.Children.Add(Wheel1);
            targetCanvas.Children.Add(Wheel2);
            targetCanvas.Children.Add(MittelKörper);
            targetCanvas.Children.Add(Fenster);
            targetCanvas.Children.Add(Spoler);
        }
        
        public static void DrawModernCarSmall(Canvas targetCanvas)
        {
            targetCanvas.Children.Clear();

            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection { 
                new Point(25, 60), new Point(175, 60), new Point(180, 55), 
                new Point(185, 40), new Point(170, 35), new Point(60, 35), new Point(30, 40) 
            };
            MittelKörper.Fill = Brushes.SteelBlue;
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 1;
            
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection { 
                new Point(65, 35), new Point(90, 15), new Point(130, 15), new Point(155, 35) 
            };
            Fenster.Fill = Brushes.LightBlue;
            Fenster.Stroke = Brushes.Black;

            Polygon Spoler = new Polygon();
            Spoler.Points = new PointCollection
            {
                new Point(27.5, 40), new Point(20, 25), new Point(40, 37.5)
            };
            Spoler.Fill = Brushes.Black;
            Spoler.Stroke = Brushes.Black;
            Spoler.StrokeThickness = 1;
            
            Ellipse Wheel1 = new Ellipse();
            Wheel1.Width = 30;
            Wheel1.Height = 30;
            Wheel1.Fill = Brushes.Silver;
            Wheel1.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel1, 35);
            Canvas.SetTop(Wheel1, 45);
    
            Ellipse Wheel2 = new Ellipse();
            Wheel2.Width = 30;
            Wheel2.Height = 30;
            Wheel2.Fill = Brushes.Silver;
            Wheel2.Stroke = Brushes.Black;
            Canvas.SetLeft(Wheel2, 135);
            Canvas.SetTop(Wheel2, 45);
            
            targetCanvas.Children.Add(Wheel1);
            targetCanvas.Children.Add(Wheel2);
            targetCanvas.Children.Add(MittelKörper);
            targetCanvas.Children.Add(Fenster);
            targetCanvas.Children.Add(Spoler);
        }
}