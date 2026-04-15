using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{
    private Car __currentCar;
    private int __currentCarIndex;


    public StatsWindow(Tire selectedTire, Brake selectedBrake, Engine selectedEngine, Frontspoiler selectedFrontspoiler,
        Heckspoiler selectedHeckspoiler, Rimm selectedRimm, int _currentCarIndex, Car _currentCar)
    private Tire _tire;
    private Brake _brake;
    private Engine _engine;
    private Frontspoiler _frontspoiler;
    private Heckspoiler _heckspoiler;
    private Rimm _rimm;
    
    
    public StatsWindow(Tire SelectedTire, Brake SelectedBrake, Engine SelectedEngine, Frontspoiler SelectedFrontspoiler, Heckspoiler SelectedHeckspoiler, Rimm SelectedRimm)
    {
        InitializeComponent();
        Progresses();

        __currentCarIndex = _currentCarIndex;
        __currentCar = _currentCar;
        
        Update();
    }
        _tire = SelectedTire;
        _brake = SelectedBrake;
        _engine = SelectedEngine;
        _frontspoiler = SelectedFrontspoiler;
        _heckspoiler = SelectedHeckspoiler;
        _rimm =  SelectedRimm;

        Progress();
    }

    private void Button_Done(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Progress()
    {
        SpeedBar.Value = speed;
        BrakeBar.Value = Brake;
        GripBar.Value = Grip;
        WeightBar.Value = Weight;
    }

    private void Update()
    {

        if (__currentCarIndex % 2 == 0)
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


        double totalWeight = _tire.Weight + _brake.Weight + _engine.Weight + _frontspoiler.Weight + _heckspoiler.Weight + _rimm.Weight;
        WeightBar.Value = totalWeight;
        
        double totalCost = _tire.Price + _brake.Price + _engine.Price + _frontspoiler.Price + _heckspoiler.Price + _rimm.Price;
        LblPrice.Content = $"{totalCost}CHF";
        
        double totalDownforce = _frontspoiler.Downforce + _heckspoiler.Downforce;
        LblDownforce.Content = $"{totalDownforce}N";
        
        LblFuelconsumption.Content = _engine.FuelConsumption;
        LblType.Content = _tire.TireType;

        SpeedBar.Value = _engine.HorsePower;
        BrakeBar.Value = _brake.Brakeforce;
        GripBar.Value = _tire.Grip;
    }