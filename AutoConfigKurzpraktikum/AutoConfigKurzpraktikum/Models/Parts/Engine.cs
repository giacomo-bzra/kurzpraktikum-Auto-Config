namespace AutoConfigKurzpraktikum.Models.Parts;

public class Engine : TuningPart
{
    public double FuelConsumption  {get; set;}

    public Engine(string name, double price, double weight, bool isInstalled, string color, double fuelConsumption) :
        base(name, price, weight, isInstalled, color)
    {
        this.FuelConsumption = fuelConsumption;
    }
    
}