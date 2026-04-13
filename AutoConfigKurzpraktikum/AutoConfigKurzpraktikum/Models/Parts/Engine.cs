namespace AutoConfigKurzpraktikum.Models.Parts;

public class Engine : TuningPart
{
    public double FuelConsumption  {get; set;}
    public double HorsePower  {get; set;}

    public Engine(string partId, string name, double price, double weight, bool isInstalled, string color, double fuelConsumption, double horsePower) :
        base(partId, name, price, weight, isInstalled, color)
    {
        this.FuelConsumption = fuelConsumption;
        this.HorsePower = horsePower;
    }
    
}