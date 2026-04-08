namespace AutoConfigKurzpraktikum.Models.Parts;

public class Brake : TuningPart
{
    public double Brakeforce {get; set;}

    public Brake(string name, double price, double weight, bool isInstalled, string color, double brakeforce) :
        base(name, price, weight, isInstalled, color)
    {
        this.Brakeforce = brakeforce;
    }
    
    
   
}