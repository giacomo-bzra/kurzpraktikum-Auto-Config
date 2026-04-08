namespace AutoConfigKurzpraktikum.Models.Parts;

public class Frontspoiler : TuningPart
{
    public double Downforce { get; set; }

    public Frontspoiler(string partId, string name, double price, double weight, bool isInstalled, string color, double downforce) :
        base(partId, name, price, weight, isInstalled, color)
    {
        this.Downforce = downforce;
    }
}