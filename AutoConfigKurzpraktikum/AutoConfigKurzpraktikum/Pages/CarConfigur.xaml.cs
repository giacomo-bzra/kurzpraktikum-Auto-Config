using System.Windows;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Service;
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum.Pages;

public partial class CarConfigur : Window
{
    private readonly IMongoCollection<Car> _carsCollection;
    private readonly CarConfigurMode _mode;

    public List<Car> AvailableCars { get; set; } = new();
    private int _currentCarIndex = 0;
    public Car? CurrentCar;

    

    public CarConfigur(CarConfigurMode mode = CarConfigurMode.New)
    {
        InitializeComponent();
        
        _mode = mode;

        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("AutoConfig");
        _carsCollection = database.GetCollection<Car>("Cars");
        
        AvailableCars = _carsCollection.Find(Builders<Car>.Filter.Empty).ToList();
        CurrentCar = AvailableCars[_currentCarIndex];
        RefreshUi();
        
        
        
        this.Title = mode == CarConfigurMode.New
            ? "Neues Auto konfigurieren"
            : "Auto bearbeiten";
    }

    public void Button_Left(object sender, RoutedEventArgs e)
    {
        if (AvailableCars.Count == 0) return;

        _currentCarIndex--;


        if (_currentCarIndex < 0)
            _currentCarIndex = AvailableCars.Count - 1;

        Console.WriteLine(_currentCarIndex);
        RefreshUi();
        CurrentCar = AvailableCars[_currentCarIndex];

    }

    public void Button_Right(object sender, RoutedEventArgs e)
    {
        if (AvailableCars.Count == 0) return;

        _currentCarIndex++;


        if (_currentCarIndex >= AvailableCars.Count)
            _currentCarIndex = 0;

        Console.WriteLine(_currentCarIndex);
        RefreshUi();
        CurrentCar = AvailableCars[_currentCarIndex];

    }

    public void Button_select(object sender, RoutedEventArgs e)
    {
        if (CurrentCar == null)
        {
            MessageBox.Show("Kein Auto ausgewählt!");
            return;
        }

        var tuneWindow = new TuneWindow(CurrentCar);
        tuneWindow.Show();
        Close();
    }
    

    private void RefreshUi()
    {
        this.Dispatcher.Invoke(() =>
        {
            this.DataContext = null;
            this.DataContext = CurrentCar;
            Update();
        });
    }

    private void Update()
    {
        if (CurrentCar == null || AutoBild == null) return;
        AutoBild.Children.Clear();

        if (CurrentCar.Brand == "BMW")
            CarPainter.DrawModernCar(AutoBild);
        else if (CurrentCar.Brand == "Oldtimer")
            CarPainter.DrawOldtimer(AutoBild);
    }
}
