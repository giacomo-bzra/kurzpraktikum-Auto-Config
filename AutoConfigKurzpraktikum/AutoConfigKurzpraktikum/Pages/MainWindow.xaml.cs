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

namespace AutoConfigKurzpraktikum;

public partial class MainWindow : Window
{
    public List<Car> AvailableCars { get; set; }
    private int _currentCarIndex = 0;
    public Car CurrentCar => AvailableCars[_currentCarIndex];
    
    public MainWindow()
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
            TuneWindow tuneWindow = new TuneWindow();
            tuneWindow.Show();
            this.Close();
    }

    private void Update()
    {
        placeholderLabel.Text = CurrentCar.Brand;

        count.Content = $"{_currentCarIndex + 1} / {AvailableCars.Count}";
    }
}