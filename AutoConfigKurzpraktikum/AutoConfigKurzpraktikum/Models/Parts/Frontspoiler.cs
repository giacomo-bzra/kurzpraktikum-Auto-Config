namespace AutoConfigKurzpraktikum.Models.Parts;

public class Frontspoiler : TuningPart
{
    public double Downforce { get; set; }

    public Frontspoiler(string name, double price, double weight, bool isInstalled, string color, double downforce) :
        base(name, price, weight, isInstalled, color)
    {
        this.Downforce = downforce;
    }
}