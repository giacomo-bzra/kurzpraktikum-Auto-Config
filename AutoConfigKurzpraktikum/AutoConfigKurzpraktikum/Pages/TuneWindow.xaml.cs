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
        
        Update();

        this.DataContext = this;
    }
    


    public void Button_select(object sender, RoutedEventArgs e)
    {
        StatsWindow statsWindow = new StatsWindow(SelectedTire, SelectedBrake, SelectedEngine, SelectedFrontspoiler,
            SelectedHeckspoiler, SelectedRimm, _currentCarIndex, _currentCar);
        statsWindow.Show();
        this.Close();
    }



    private void Update()
    {

        if (_currentCarIndex % 2 == 0)
        {
            AutoBild.Children.Clear();
            Polygon MittelKörper = new Polygon();
            MittelKörper.Points = new PointCollection
            {
                new Point(25, 60), new Point(175, 60), new Point(180, 55),
                new Point(185, 40), new Point(170, 35), new Point(60, 35), new Point(30, 40)
            };
            MittelKörper.Fill = Brushes.SteelBlue;
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
            MittelKörper.Points = new PointCollection
            {
                new Point(15, 60), new Point(185, 60), new Point(185, 40), new Point(170, 35), new Point(60, 35),
                new Point(15, 40)
            };
            MittelKörper.Fill = Brushes.SaddleBrown;
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

            AutoBild.Children.Add(Wheel1);
            AutoBild.Children.Add(Wheel2);
            AutoBild.Children.Add(MittelKörper);
            AutoBild.Children.Add(Fenster);
            AutoBild.Children.Add(Spoler);
        }
    }
}

    
