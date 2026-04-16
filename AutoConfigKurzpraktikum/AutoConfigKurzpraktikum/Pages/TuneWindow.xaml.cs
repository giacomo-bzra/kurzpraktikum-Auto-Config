using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Pages;
using AutoConfigKurzpraktikum.Models.Parts;
using AutoConfigKurzpraktikum.Service;
using MongoDB.Driver;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace AutoConfigKurzpraktikum;

public partial class TuneWindow : Window
{
    
    
        private readonly IMongoCollection<Car> _carsCollection;
        private readonly IMongoCollection<TuningPart> _partsCollection;
        
        public Car SelectedCar { get; set; }
    
        CarConfigur Draw = new CarConfigur();
        
        public List<Car> AvailableCars { get; set; } = new();
    

        
        
        public List<Tire> TireOptions { get; set; } = new();
        public List<Brake> BrakeOptions { get; set; } = new();
        public List<Engine> EngineOptions { get; set; } = new();
        public List<Frontspoiler> FrontspoilerOptions { get; set; } = new();
        public List<Heckspoiler> HeckspoilerOptions { get; set; } = new();
        public List<Rimm> RimmOptions { get; set; } = new();
        
        public Tire SelectedTire { get; set; }
        public Brake SelectedBrake { get; set; }
        public Engine SelectedEngine { get; set; }
        public Frontspoiler SelectedFrontspoiler { get; set; }
        public Heckspoiler SelectedHeckspoiler { get; set; }
        public Rimm SelectedRimm { get; set; }

        public TuneWindow(Car carFromConfig)
        {
            InitializeComponent();
            
            SelectedCar = carFromConfig;
            this.DataContext = this;
            
             var client = new MongoClient("mongodb://localhost:27017/");
             var database = client.GetDatabase("AutoConfig");
             _partsCollection = database.GetCollection<TuningPart>("Parts");
            
            _ = LoadPartsFromDatabaseAndSetDefaults();

            UpdateCarVisuals();
        }
        
        public async Task LoadPartsFromDatabaseAndSetDefaults()
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
                
                if (SelectedCar.InstalledParts != null)
                {
                    SelectedEngine = EngineOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Engine>().FirstOrDefault()?.PartId);
                    SelectedBrake = BrakeOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Brake>().FirstOrDefault()?.PartId);
                    SelectedTire = TireOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Tire>().FirstOrDefault()?.PartId);
                    SelectedRimm = RimmOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Rimm>().FirstOrDefault()?.PartId);
                    SelectedFrontspoiler = FrontspoilerOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Frontspoiler>().FirstOrDefault()?.PartId);
                    SelectedHeckspoiler = HeckspoilerOptions.FirstOrDefault(x => x.PartId == SelectedCar.InstalledParts.OfType<Heckspoiler>().FirstOrDefault()?.PartId);
                }

                this.DataContext = null;
                this.DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }

        private void UpdateCarVisuals()
        {
            if (SelectedCar == null) return;

            if (SelectedCar.Modell == "M3")
            {
                CarPainter.DrawModernCarSmall(AutoBild);
            }
            else
            {
                CarPainter.DrawOldtimerSmall(AutoBild);
            }
        }
        
    
        public void Button_Select(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow(
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
}

    
