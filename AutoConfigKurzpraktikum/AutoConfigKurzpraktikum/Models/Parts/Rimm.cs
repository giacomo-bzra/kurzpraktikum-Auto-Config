namespace AutoConfigKurzpraktikum.Models.Parts;

public class Rimm : TuningPart
{
    public double Diameter { get; set; }

    public Rimm(string name, double price, double weight, bool isInstalled, string color, double diameter) :
        base(name, price, weight, isInstalled, color)
    {
        this.Diameter = diameter;
    } 

}