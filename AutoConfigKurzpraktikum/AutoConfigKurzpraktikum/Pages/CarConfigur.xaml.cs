using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Service;

namespace AutoConfigKurzpraktikum.Pages;

public partial class CarConfigur : Window
{
    public List<Car> AvailableCars { get; set; }
    private int _currentCarIndex = 0;
    public Car CurrentCar => AvailableCars[_currentCarIndex];
    
    public CarConfigur()
    {
        InitializeComponent();
        AvailableCars = new List<Car>
        {
            BaseCar.CreateDefault(),
            BaseCar.CreateRustyBase()
        };
        
        this.DataContext = CurrentCar;
        Update();
    }

    public void Button_Left(object sender, RoutedEventArgs e)
    {
        _currentCarIndex = (_currentCarIndex + 1) % AvailableCars.Count;
        Update();
    }

    public void Button_Right(object sender, RoutedEventArgs e)
    {
        _currentCarIndex--;
        if (_currentCarIndex < 0)
        {
            _currentCarIndex = AvailableCars.Count - 1;
        }
        Update();
    }
    
    public void Button_select(object sender, RoutedEventArgs e)
    {
            TuneWindow tuneWindow = new TuneWindow(CurrentCar, _currentCarIndex);
            tuneWindow.Show();
            this.Close();
    }

    private void Update()
    {

        if (_currentCarIndex == 0)
        {
            AutoBild.Children.Clear();
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
            
            AutoBild.Children.Add(Wheel1);
            AutoBild.Children.Add(Wheel2);
            AutoBild.Children.Add(MittelKörper);
            AutoBild.Children.Add(Fenster);
            AutoBild.Children.Add(Spoler);
        }
        else
        {
            AutoBild.Children.Clear();
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
            
            AutoBild.Children.Add(Wheel1);
            AutoBild.Children.Add(Wheel2);
            AutoBild.Children.Add(MittelKörper);
            AutoBild.Children.Add(Fenster);
            AutoBild.Children.Add(Spoler);
        }
        
    }
    
    
}