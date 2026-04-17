using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Pages;
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private List<Car> _savedCars = new();
    public List<Car> SavedCars
    {
        get => _savedCars;
        set { _savedCars = value; OnPropertyChanged(); OnPropertyChanged(nameof(EmptyStateVisibility)); }
    }

    private Car? _selectedCar;
    public Car? SelectedCar
    {
        get => _selectedCar;
        set { _selectedCar = value; OnPropertyChanged(); }
    }

    public Visibility EmptyStateVisibility
        => SavedCars.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadCars();
    }

    public async Task LoadCars()
    {
        try
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("AutoConfig");
            var collection = database.GetCollection<Car>("Cars");

 
            var filter = Builders<Car>.Filter.And(
                Builders<Car>.Filter.Ne(c => c.InstalledParts, null),
                Builders<Car>.Filter.SizeGt(c => c.InstalledParts, 0)
            );

            SavedCars = await collection.Find(filter).ToListAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler beim Laden: {ex.Message}");
        }
    }


    public void Button_CreateNew(object sender, RoutedEventArgs e)
    {
        var carConfigur = new CarConfigur();
        carConfigur.Show();
        this.Close();
    }

    public void Button_Edit(object sender, RoutedEventArgs e)
    {
        if (SelectedCar == null)
        {
            MessageBox.Show("Bitte zuerst ein Auto aus der Liste auswählen.", "Kein Auto gewählt",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var tuneWindow = new TuneWindow(SelectedCar);
        tuneWindow.Show();
        this.Close();
    }
    
    public async void Button_Delete(object sender, RoutedEventArgs e)
    {
        if (SelectedCar == null)
        {
            MessageBox.Show("Bitte zuerst ein Auto aus der Liste auswählen.", "Kein Auto gewählt",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var result = MessageBox.Show(
            $"Soll '{SelectedCar.Brand} {SelectedCar.Modell}' wirklich gelöscht werden?",
            "Löschen bestätigen",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (result != MessageBoxResult.Yes) return;

        try
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("AutoConfig");
            var collection = database.GetCollection<Car>("Cars");

            await collection.DeleteOneAsync(c => c.CarId == SelectedCar.CarId);
            MessageBox.Show($"'{SelectedCar.Brand} {SelectedCar.Modell}' wurde gelöscht.");
            await LoadCars();
            SelectedCar = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler beim Löschen: {ex.Message}");
        }
    }
}