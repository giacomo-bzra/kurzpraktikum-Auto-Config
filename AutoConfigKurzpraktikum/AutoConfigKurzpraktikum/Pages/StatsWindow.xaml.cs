using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Models.Parts;
using AutoConfigKurzpraktikum.Service;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{

    public StatsWindow(Car selectedCar, Brake selectedBrake, Engine selectedEngine, Frontspoiler selectedFrontspoiler,
        Heckspoiler selectedHeckspoiler, Rimm selectedRimm, Tire selectedTire)
    {

        InitializeComponent();
        double totalHorsepower = selectedCar.BaseHorsepower + selectedEngine?.HorsePower ?? 0;
        
        double totalWeiht = selectedCar.BaseWeight
            +(selectedEngine?.Weight ?? 0)
            + (selectedBrake?.Weight ?? 0)
            +(selectedFrontspoiler?.Weight ?? 0)
            +(selectedHeckspoiler?.Weight ?? 0)
            +(selectedRimm?.Weight ?? 0)
            +(selectedTire?.Weight ?? 0);

        double totalBrakeForce = (selectedBrake?.Brakeforce ?? 0);
        double totalGrip = (selectedTire?.Grip ?? 0);
        double totalDownforce = (selectedFrontspoiler?.Downforce ?? 0) + (selectedHeckspoiler?.Downforce ?? 0);
        double totalFuel = (selectedEngine?.FuelConsumption ?? 0);
        
        double totalPrice = selectedCar.Price
            + (selectedEngine?.Price ?? 0)
            +(selectedBrake?.Price ?? 0)
            + (selectedFrontspoiler?.Price ?? 0)
            + (selectedHeckspoiler?.Price ?? 0)
            +(selectedRimm?.Price ?? 0)
            +(selectedTire?.Price ?? 0);
        
        SpeedBar.Value = totalHorsepower;
        BrakeBar.Value = totalBrakeForce;
        GripBar.Value = totalGrip;
        WeightBar.Value = totalWeiht;

        lblName.Content = $"{selectedCar.Brand} {selectedCar.Modell}";
        lblPrice.Content = $"{totalPrice} CHF";
        lblDownforce.Content = $"{totalDownforce} N";
        lblFuelconsumption.Content = $"{totalFuel} L/100km";

        DrawCar(selectedCar.Modell);

    }

    private void DrawCar(string model)
    {
        AutoBild.Children.Clear();
        if (model == "M3")
        {
            CarPainter.DrawModernCarSmall(AutoBild);
        }
        else
        {
            CarPainter.DrawOldtimerSmall(AutoBild);
            
        }
        
    }
    
    public void Button_Done(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}