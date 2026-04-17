using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AutoConfigKurzpraktikum.Service;

public static class CarPainter
{
    public static void DrawOldtimer(Canvas targetCanvas)
        => DrawOldtimerColored(targetCanvas, Colors.SaddleBrown);

    public static void DrawOldtimerSmall(Canvas targetCanvas)
        => DrawOldtimerSmallColored(targetCanvas, Colors.SaddleBrown);

    public static void DrawModernCar(Canvas targetCanvas)
        => DrawModernCarColored(targetCanvas, Colors.SteelBlue);

    public static void DrawModernCarSmall(Canvas targetCanvas)
        => DrawModernCarSmallColored(targetCanvas, Colors.SteelBlue);
    

    public static void DrawOldtimerColored(Canvas targetCanvas, Color bodyColor)
    {
        targetCanvas.Children.Clear();
        var body = new SolidColorBrush(bodyColor);

        var mittelKörper = new Polygon
        {
            Points = new PointCollection
            {
                new(30, 120), new(370, 120), new(370, 80),
                new(340, 70), new(120, 70), new(30, 80)
            },
            Fill = body,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var fenster = new Polygon
        {
            Points = new PointCollection
            {
                new(100, 70), new(140, 40), new(310, 40), new(340, 70)
            },
            Fill = Brushes.LightBlue,
            Stroke = Brushes.Black
        };

        var spoler = new Polygon
        {
            Points = new PointCollection
            {
                new(30, 75), new(60, 70), new(60, 76), new(64, 70),
                new(100, 65), new(100, 55), new(30, 65)
            },
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var wheel1 = MakeEllipse(60, 60, 70, 90, Brushes.Silver);
        var wheel2 = MakeEllipse(60, 60, 270, 90, Brushes.Silver);

        targetCanvas.Children.Add(wheel1);
        targetCanvas.Children.Add(wheel2);
        targetCanvas.Children.Add(mittelKörper);
        targetCanvas.Children.Add(fenster);
        targetCanvas.Children.Add(spoler);
    }

    public static void DrawOldtimerSmallColored(Canvas targetCanvas, Color bodyColor)
    {
        targetCanvas.Children.Clear();
        var body = new SolidColorBrush(bodyColor);

        var mittelKörper = new Polygon
        {
            Points = new PointCollection
            {
                new(15, 60), new(185, 60), new(185, 40),
                new(170, 35), new(60, 35), new(15, 40)
            },
            Fill = body,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        var fenster = new Polygon
        {
            Points = new PointCollection
            {
                new(50, 35), new(70, 20), new(155, 20), new(170, 35)
            },
            Fill = Brushes.LightBlue,
            Stroke = Brushes.Black
        };

        var spoler = new Polygon
        {
            Points = new PointCollection
            {
                new(15, 37.5), new(30, 35), new(30, 38),
                new(32, 35), new(50, 32.5), new(50, 27.5), new(15, 32.5)
            },
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        var wheel1 = MakeEllipse(30, 30, 35, 45, Brushes.Silver);
        var wheel2 = MakeEllipse(30, 30, 135, 45, Brushes.Silver);

        targetCanvas.Children.Add(wheel1);
        targetCanvas.Children.Add(wheel2);
        targetCanvas.Children.Add(mittelKörper);
        targetCanvas.Children.Add(fenster);
        targetCanvas.Children.Add(spoler);
    }

    public static void DrawModernCarColored(Canvas targetCanvas, Color bodyColor)
    {
        targetCanvas.Children.Clear();
        var body = new SolidColorBrush(bodyColor);

        var mittelKörper = new Polygon
        {
            Points = new PointCollection
            {
                new(50, 120), new(350, 120), new(360, 110),
                new(370, 80), new(340, 70), new(120, 70), new(60, 80)
            },
            Fill = body,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var fenster = new Polygon
        {
            Points = new PointCollection
            {
                new(130, 70), new(180, 30), new(260, 30), new(310, 70)
            },
            Fill = Brushes.LightBlue,
            Stroke = Brushes.Black
        };

        var spoler = new Polygon
        {
            Points = new PointCollection
            {
                new(55, 80), new(40, 50), new(80, 75)
            },
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        var wheel1 = MakeEllipse(60, 60, 70, 90, Brushes.Silver);
        var wheel2 = MakeEllipse(60, 60, 270, 90, Brushes.Silver);

        targetCanvas.Children.Add(wheel1);
        targetCanvas.Children.Add(wheel2);
        targetCanvas.Children.Add(mittelKörper);
        targetCanvas.Children.Add(fenster);
        targetCanvas.Children.Add(spoler);
    }

    public static void DrawModernCarSmallColored(Canvas targetCanvas, Color bodyColor)
    {
        targetCanvas.Children.Clear();
        var body = new SolidColorBrush(bodyColor);

        var mittelKörper = new Polygon
        {
            Points = new PointCollection
            {
                new(25, 60), new(175, 60), new(180, 55),
                new(185, 40), new(170, 35), new(60, 35), new(30, 40)
            },
            Fill = body,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        var fenster = new Polygon
        {
            Points = new PointCollection
            {
                new(65, 35), new(90, 15), new(130, 15), new(155, 35)
            },
            Fill = Brushes.LightBlue,
            Stroke = Brushes.Black
        };

        var spoler = new Polygon
        {
            Points = new PointCollection
            {
                new(27.5, 40), new(20, 25), new(40, 37.5)
            },
            Fill = Brushes.Black,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        var wheel1 = MakeEllipse(30, 30, 35, 45, Brushes.Silver);
        var wheel2 = MakeEllipse(30, 30, 135, 45, Brushes.Silver);

        targetCanvas.Children.Add(wheel1);
        targetCanvas.Children.Add(wheel2);
        targetCanvas.Children.Add(mittelKörper);
        targetCanvas.Children.Add(fenster);
        targetCanvas.Children.Add(spoler);
    }
    
    private static Ellipse MakeEllipse(double w, double h, double left, double top, Brush fill)
    {
        var e = new Ellipse
        {
            Width = w,
            Height = h,
            Fill = fill,
            Stroke = Brushes.Black
        };
        Canvas.SetLeft(e, left);
        Canvas.SetTop(e, top);
        return e;
    }
}