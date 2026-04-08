using System.Collections;

namespace AutoConfigKurzpraktikum.Models;

public class Auto
{
    
    public string Marke {get;set;}
    public string Modell {get;set;}
    public double Price {get;set;}
    public int BaseHorsepower {get;set;}
    public int CurrentHorsepower {get;set;}
    public int BaseWeight {get;set;}
    public int CurrentWeight {get;set;}

    public List<TuningParts> TuningParts { get; set; } = new ArrayList();

}