using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Pages;
using AutoConfigKurzpraktikum.Service;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum;

public partial class TuneWindow : Window
{
    private Car _currentCar;
    private int _currentCarIndex;

    public List<Tire> TireOptions => PartsCollection.AllTires;
    public List<Brake> BrakeOptions => PartsCollection.AllBrakes;
    public List<Engine> EngineOptions => PartsCollection.AllEngines;
    public List<Frontspoiler> FrontspoilerOptons => PartsCollection.AllFrontspoilers;
    public List<Heckspoiler> HeckspoilerOptions => PartsCollection.AllHeckspoilers;
    public List<Rimm> RimmOptions => PartsCollection.AllRimms;


    public Tire SelectedTire { get; set; }
    public Brake SelectedBrake { get; set; }
    public Engine SelectedEngine { get; set; }
    public Frontspoiler SelectedFrontspoiler { get; set; }
    public Heckspoiler SelectedHeckspoiler { get; set; }
    public Rimm SelectedRimm { get; set; }

    public TuneWindow(Car currentCar, int currentCarIndex)
    {

        InitializeComponent();
        SelectedTire = TireOptions.FirstOrDefault();
        SelectedBrake = BrakeOptions.FirstOrDefault();
        SelectedEngine = EngineOptions.FirstOrDefault();
        SelectedFrontspoiler = FrontspoilerOptons.FirstOrDefault();
        SelectedHeckspoiler = HeckspoilerOptions.FirstOrDefault();
        SelectedRimm = RimmOptions.FirstOrDefault();
        
        _currentCar = currentCar;
        _currentCarIndex = currentCarIndex;
        
        if (_currentCarIndex % 2 == 0)
        {
            ColorAuswahl.SelectedColor = Colors.SteelBlue;
        }
        else
        {
            ColorAuswahl.SelectedColor = Colors.SaddleBrown;
        }

        this.DataContext = this;
        
        Update();
    }
    
    
    public void Button_select(object sender, RoutedEventArgs e)
    {
        StatsWindow statsWindow = new StatsWindow(SelectedTire, SelectedBrake, SelectedEngine, SelectedFrontspoiler,
            SelectedHeckspoiler, SelectedRimm, _currentCarIndex, _currentCar);
        statsWindow.Show();
        this.Close();
    }

    public void ColorUpdate(object sender, RoutedEventArgs e)
    {
        Update();
    }

    private void Update()
    {
        Color gewählteFarbe = ColorAuswahl.SelectedColor ?? Colors.SteelBlue;
        Brush autoPinsel = new SolidColorBrush(gewählteFarbe);
        
        AutoBild.Children.Clear();
    
        if (_currentCarIndex % 2 == 0)
        {
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection
            {
                new Point(25, 60), new Point(175, 60), new Point(180, 55),
                new Point(185, 40), new Point(170, 35), new Point(60, 35), new Point(30, 40)
            };
            MittelKörper.Fill = autoPinsel; // Hier den Pinsel nutzen
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 2;
    
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection
            {
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
            Spoler.StrokeThickness = 2;
    
            ZeichneRäder();
    
            AutoBild.Children.Add(MittelKörper);
            AutoBild.Children.Add(Fenster);
            AutoBild.Children.Add(Spoler);
        }
        else
        {
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection
            {
                new Point(15, 60), new Point(185, 60), new Point(185, 40), new Point(170, 35), new Point(60, 35),
                new Point(15, 40)
            };
            MittelKörper.Fill = autoPinsel;
            MittelKörper.Stroke = Brushes.Black;
            MittelKörper.StrokeThickness = 2;
    
            Polygon Fenster = new Polygon();
            Fenster.Points = new PointCollection
            {
                new Point(50, 35), new Point(70, 20), new Point(155, 20), new Point(170, 35)
            };
            Fenster.Fill = Brushes.LightBlue;
            Fenster.Stroke = Brushes.Black;
    
            Polygon Spoler = new Polygon();
            Spoler.Points = new PointCollection
            {
                new Point(15, 37.5), new Point(30, 35), new Point(30, 38), new Point(32, 35), new Point(50, 32.5),
                new Point(50, 27.5), new Point(15, 32.5)
            };
            Spoler.Fill = Brushes.Black;
            Spoler.Stroke = Brushes.Black;
            Spoler.StrokeThickness = 2;
    
            ZeichneRäder();
    
            AutoBild.Children.Add(MittelKörper);
            AutoBild.Children.Add(Fenster);
            AutoBild.Children.Add(Spoler);
        }
    }

    private void ZeichneRäder()
    {
        Ellipse Wheel1 = new Ellipse { Width = 30, Height = 30, Fill = Brushes.Silver, Stroke = Brushes.Black };
        Canvas.SetLeft(Wheel1, 35); Canvas.SetTop(Wheel1, 45);
        
        Ellipse Wheel2 = new Ellipse { Width = 30, Height = 30, Fill = Brushes.Silver, Stroke = Brushes.Black };
        Canvas.SetLeft(Wheel2, 135); Canvas.SetTop(Wheel2, 45);
    
        AutoBild.Children.Add(Wheel1);
        AutoBild.Children.Add(Wheel2);
    }
}

    
