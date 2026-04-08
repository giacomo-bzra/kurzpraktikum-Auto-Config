using System.Collections;
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
    

    public List<TuningPart> TuningParts { get; set; } = new List<TuningPart>();

}