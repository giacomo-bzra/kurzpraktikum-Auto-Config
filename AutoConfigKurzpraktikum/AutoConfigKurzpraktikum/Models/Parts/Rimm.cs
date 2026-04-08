namespace AutoConfigKurzpraktikum.Models.Parts;

public class Rimm : TuningPart
{
    public double Diameter { get; set; }

    public Rimm(string partId, string name, double price, double weight, bool isInstalled, string color, double diameter) :
        base(partId, name, price, weight, isInstalled, color)
    {
        this.Diameter = diameter;
    } 

}