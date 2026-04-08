namespace AutoConfigKurzpraktikum.Models.Parts;

public class Brake : TuningPart
{
    public double Brakeforce {get; set;}

    public Brake(string partId, string name, double price, double weight, bool isInstalled, string color, double brakeforce) :
        base(partId, name, price, weight, isInstalled, color)
    {
        this.Brakeforce = brakeforce;
    }
    
    
   
}