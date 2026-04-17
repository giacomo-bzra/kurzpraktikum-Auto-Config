using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Pages;
using AutoConfigKurzpraktikum.Models.Parts;
using AutoConfigKurzpraktikum.Service;
using MongoDB.Driver;
using MessageBox = System.Windows.MessageBox;
namespace AutoConfigKurzpraktikum;

public partial class TuneWindow : Window
{

    private readonly IMongoCollection<TuningPart> _partsCollection;

    public Car SelectedCar { get; set; }

    public List<Tire> TireOptions { get; set; } = new();
    public List<Brake> BrakeOptions { get; set; } = new();
    public List<Engine> EngineOptions { get; set; } = new();
    public List<Frontspoiler> FrontspoilerOptions { get; set; } = new();
    public List<Heckspoiler> HeckspoilerOptions { get; set; } = new();
    public List<Rimm> RimmOptions { get; set; } = new();

    public Tire? SelectedTire { get; set; }
    public Brake? SelectedBrake { get; set; }
    public Engine? SelectedEngine { get; set; }
    public Frontspoiler? SelectedFrontspoiler { get; set; }
    public Heckspoiler? SelectedHeckspoiler { get; set; }
    public Rimm? SelectedRimm { get; set; }

    private Color _carBodyColor { get; set; }

    public TuneWindow(Car carFromConfig)
    {
        InitializeComponent();

        SelectedCar = carFromConfig;
        _carBodyColor = HexToRgb(SelectedCar.Color);
        DataContext = this;

        var client = new MongoClient("mongodb://localhost:27017/");
        var database = client.GetDatabase("AutoConfig");
        _partsCollection = database.GetCollection<TuningPart>("Parts");

        _ = LoadPartsAndSetDefaults();
        UpdateCarVisuals();
    }

    public async Task LoadPartsAndSetDefaults()
    {
        try
        {
            var allParts = await _partsCollection.Find(_ => true).ToListAsync();

            EngineOptions = allParts.OfType<Engine>().ToList();
            TireOptions = allParts.OfType<Tire>().ToList();
            BrakeOptions = allParts.OfType<Brake>().ToList();
            RimmOptions = allParts.OfType<Rimm>().ToList();
            FrontspoilerOptions = allParts.OfType<Frontspoiler>().ToList();
            HeckspoilerOptions = allParts.OfType<Heckspoiler>().ToList();

            var source = (SelectedCar.InstalledParts != null && SelectedCar.InstalledParts.Any())
                         ? SelectedCar.InstalledParts
                         : SelectedCar.InitialParts;

            if (source != null)
            {
                SelectedEngine = EngineOptions.FirstOrDefault(x => x.Name == source.OfType<Engine>().FirstOrDefault()?.Name);
                SelectedBrake = BrakeOptions.FirstOrDefault(x => x.Name == source.OfType<Brake>().FirstOrDefault()?.Name);
                SelectedTire = TireOptions.FirstOrDefault(x => x.Name == source.OfType<Tire>().FirstOrDefault()?.Name);
                SelectedRimm = RimmOptions.FirstOrDefault(x => x.Name == source.OfType<Rimm>().FirstOrDefault()?.Name);
                SelectedFrontspoiler = FrontspoilerOptions.FirstOrDefault(x => x.Name == source.OfType<Frontspoiler>().FirstOrDefault()?.Name);
                SelectedHeckspoiler = HeckspoilerOptions.FirstOrDefault(x => x.Name == source.OfType<Heckspoiler>().FirstOrDefault()?.Name);
            }

            DataContext = null;
            DataContext = this;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler: {ex.Message}");
        }
    }

    private void UpdateCarVisuals()
    {
        if (SelectedCar == null) return;

        if (SelectedCar.Brand == "BMW")
            CarPainter.DrawModernCarSmallColored(AutoBild, _carBodyColor);
        else if (SelectedCar.Brand == "Oldtimer")
            CarPainter.DrawOldtimerSmallColored(AutoBild, _carBodyColor);
    }

    private void CarColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
    {
        if (e.NewValue.HasValue)
        {
            ApplyColor(e.NewValue.Value);
        }
    }

    private void Swatch_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is string hex)
        {
            try
            {
                var color = (Color)ColorConverter.ConvertFromString(hex);
                ApplyColor(color);

                if (CarColorPicker != null)
                    CarColorPicker.SelectedColor = color;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ungültiger Hex-Code: {ex.Message}");
            }
        }
    }

    private void ApplyColor(Color color)
    {
        _carBodyColor = color;
        
        if (SelectedColorPreview != null)
            SelectedColorPreview.Background = new SolidColorBrush(color);
        
        UpdateCarVisuals();
    }
    

    public async void Button_Select(object sender, RoutedEventArgs e)
    {
        try
        {
            SelectedCar.CarId = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            SelectedCar.InstalledParts = new List<TuningPart?>
            {
                SelectedEngine,
                SelectedBrake,
                SelectedHeckspoiler,
                SelectedFrontspoiler,
                SelectedRimm,
                SelectedTire
            }.Where(p => p != null).Cast<TuningPart>().ToList();
            

            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("AutoConfig");
            var carsCollection = database.GetCollection<Car>("Cars");

            await carsCollection.InsertOneAsync(SelectedCar);

            MessageBox.Show($"'{SelectedCar.Brand} {SelectedCar.Modell}' erfolgreich gespeichert!");

            var statsWindow = new StatsWindow(
                SelectedCar,
                SelectedBrake,
                SelectedEngine,
                SelectedFrontspoiler,
                SelectedHeckspoiler,
                SelectedRimm,
                SelectedTire
            );
            statsWindow.Show();
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler beim Speichern: {ex.Message}");
        }
    }
    
    public static Color HexToRgb(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("Invalid hex color");

        // Remove '#' if present
        hex = hex.TrimStart('#');

        if (hex.Length != 6)
            throw new ArgumentException("Hex color must be 6 characters long.");

        var r = Convert.ToInt32(hex.Substring(0, 2), 16);
        var g = Convert.ToInt32(hex.Substring(2, 2), 16);
        var b = Convert.ToInt32(hex.Substring(4, 2), 16);

        return Color.FromRgb((byte)r, (byte)g, (byte)b);
    }
}