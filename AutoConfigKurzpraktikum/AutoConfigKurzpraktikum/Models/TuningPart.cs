using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoConfigKurzpraktikum.Models;

public abstract class TuningPart
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string PartId { get; set; }
    
    public string Name { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
    public bool IsInstalled { get; set; }
    public string Color { get; set; }

    public TuningPart(string name, double price, double weight, bool isInstalled,  string color)
    {
        this.Name = name ;
        this.Price = price;
        this.Weight = weight;
        this.IsInstalled = isInstalled;
        this.Color = color;
    }
}