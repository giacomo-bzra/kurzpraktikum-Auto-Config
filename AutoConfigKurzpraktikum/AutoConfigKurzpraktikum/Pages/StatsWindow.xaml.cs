using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{
    public StatsWindow(Tire selectedTire, Brake selectedBrake, Engine selectedEngine, Frontspoiler selectedFrontspoiler, Heckspoiler selectedHeckspoiler, Rimm selectedRimm)
    {
        InitializeComponent();
        Progresses();
    }



    public void Button_Done(object sender, RoutedEventArgs e) {
        this.Close();
    }

    private int speed = 300;
    private int Brake = 220;
    private int Grip = 700;
    private int Weight = 800;
    private int Cost = 500;
    
    private void Progresses()
    {
        SpeedBar.Value = speed;
        BrakeBar.Value = Brake;
        GripBar.Value = Grip;
        WeightBar.Value = Weight;
    }
    
    }