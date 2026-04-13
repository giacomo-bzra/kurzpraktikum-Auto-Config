using System.Windows;
using AutoConfigKurzpraktikum.Pages;
using AutoConfigKurzpraktikum.Service;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum;

public partial class TuneWindow : Window
{
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
    
    public TuneWindow()
    {
        InitializeComponent();
        SelectedTire = TireOptions.FirstOrDefault();
        SelectedBrake = BrakeOptions.FirstOrDefault();
        SelectedEngine = EngineOptions.FirstOrDefault();
        SelectedFrontspoiler = FrontspoilerOptons.FirstOrDefault();
        SelectedHeckspoiler = HeckspoilerOptions.FirstOrDefault();
        SelectedRimm = RimmOptions.FirstOrDefault();
        
        this.DataContext = this;
    }

    public void Button_select(object sender, RoutedEventArgs e)
    {
        StatsWindow statsWindow = new StatsWindow(SelectedTire, SelectedBrake, SelectedEngine, SelectedFrontspoiler, SelectedHeckspoiler, SelectedRimm);
        statsWindow.Show();
        this.Close();
    }
    
    
}