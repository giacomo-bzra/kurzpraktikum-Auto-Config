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
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum.Pages;

public partial class CarConfigur : Window
{
    private readonly IMongoCollection<Car> _carsCollection;
    public List<Car> AvailableCars { get; set; }
    private int _currentCarIndex = 0;
    
    public Car CurrentCar => AvailableCars.Count > 0 ? AvailableCars[_currentCarIndex] : null;
    
    public CarConfigur()
    {
        InitializeComponent();
        
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("AutoConfig");
        _carsCollection = database.GetCollection<Car>("Cars");

        LoadCarsFromDatabase();
    }

    private async Task LoadCarsFromDatabase()
    {
        var cars = await _carsCollection.Find(_ => true).ToListAsync();

        if (cars.Any())
        {
            AvailableCars = cars;
            _currentCarIndex = 0;

            this.DataContext = CurrentCar;
            Update();
        }
        else
        {
            MessageBox.Show("Kein Auto gefunden!");
        }
    }

    public void Button_Left(object sender, RoutedEventArgs e)
    {
        if(AvailableCars.Count == 0) return;
        _currentCarIndex = (_currentCarIndex + 1) % AvailableCars.Count;
        RefreshUI();
    }

    public void Button_Right(object sender, RoutedEventArgs e)
    {
        if(AvailableCars.Count == 0) return;
        _currentCarIndex--;
        if (_currentCarIndex < 0)
        {
            _currentCarIndex = AvailableCars.Count - 1;
        }

        RefreshUI();
    }
    
    
    private void RefreshUI()
    {
        this.DataContext = null;
        this.DataContext = CurrentCar;
        Update();
    }
    
    public void Button_select(object sender, RoutedEventArgs e)
    {
        TuneWindow tuneWindow = new TuneWindow(CurrentCar);
        tuneWindow.Show();
        this.Close();
    }

    private void Update()
    {

        if (CurrentCar == null) return;
        AutoBild.Children.Clear();

        if (CurrentCar.Modell == "M3")
        {
            CarPainter.DrawModernCar(AutoBild);
        }
        else
        {
           CarPainter.DrawOldtimer(AutoBild);
        }
    }
}