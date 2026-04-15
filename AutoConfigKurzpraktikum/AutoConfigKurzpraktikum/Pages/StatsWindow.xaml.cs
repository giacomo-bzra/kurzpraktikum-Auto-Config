using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{
    private Tire _tire;
    private Brake _brake;
    private Engine _engine;
    private Frontspoiler _frontspoiler;
    private Heckspoiler _heckspoiler;
    private Rimm _rimm;
    
    
    public StatsWindow(Tire SelectedTire, Brake SelectedBrake, Engine SelectedEngine, Frontspoiler SelectedFrontspoiler, Heckspoiler SelectedHeckspoiler, Rimm SelectedRimm)
    {
        InitializeComponent();
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
}