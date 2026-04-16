using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoConfigKurzpraktikum.Models;

public class Car
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CarId { get; set; }
    public string Brand {get;set;}
    public string Modell {get;set;}
    public double Price {get;set;}
    public int BaseHorsepower {get;set;}
    public int CurrentHorsepower {get;set;}
    public double BaseWeight {get;set;}
    public double CurrentWeight {get;set;}
    
    
    

    public List<TuningPart> InstalledParts { get; set; }
    public List<TuningPart> InitialParts { get; set; }
    
    public Car( string carId, string brand, string modell, double price, int baseHorsepower, int currentHorsepower, double baseWeight, double currentWeight, List<TuningPart> initialParts)
    {
        this.CarId = carId;
        this.Brand = brand;
        this.Modell = modell;
        this.Price = price;
        this.BaseHorsepower = baseHorsepower;
        this.CurrentHorsepower = currentHorsepower;
        this.BaseWeight = baseWeight;
        this.CurrentWeight = currentWeight;
        this.InstalledParts = InitialParts ?? new List<TuningPart>();
    }

    public void AddTuningPart(TuningPart part)
    {
        InstalledParts.Add(part);
    }
}