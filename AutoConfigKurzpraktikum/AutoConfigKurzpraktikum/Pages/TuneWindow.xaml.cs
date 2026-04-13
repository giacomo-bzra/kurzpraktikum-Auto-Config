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
    
    public TuneWindow()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    public void Button_select(object sender, RoutedEventArgs e)
    {
        StatsWindow statsWindow = new StatsWindow();
        statsWindow.Show();
        this.Close();
    }
    
    
}