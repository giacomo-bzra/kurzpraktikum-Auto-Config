using System.Security.Cryptography;
using AutoConfigKurzpraktikum.Models.Parts;
using MongoDB.Bson;
using Type = AutoConfigKurzpraktikum.Models.Parts.Type;

namespace AutoConfigKurzpraktikum.Models;

public static class BaseCar
{
    public static Car CreateDefault(string brand = "BMW", string model = "M3")
    {
        return new Car(
            carId: ObjectId.GenerateNewId().ToString(),
            brand: brand,
            modell: model,
            price: 45_000.00,
            baseHorsepower: 300,
            currentHorsepower: 300,
            baseWeight: 1_500.0,
            currentWeight: 1_500.0,
            initialParts: new()
            {
                new Engine(ObjectId.GenerateNewId().ToString(), "Standart V6", 0, 300, true, "Black", 10.5, 100),
                new Brake(ObjectId.GenerateNewId().ToString(), "Basis Lippe", 0, 5.0,  true, "Black", 100 ),
                new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Basic Front", 0, 10, true, "Black", 70),
                new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Basis Heck", 0, 10, true, "Black", 70 ),
                new Tire(ObjectId.GenerateNewId().ToString(), "Basic Tire", 0, 5, true, "Black", Type.Race, 5, 15 ),
                new Rimm(ObjectId.GenerateNewId().ToString(), "Basis Rimm", 0, 5, true, "Black", 50 )
            }
        );
    }
    
    public static Car CreateRustyBase(string brand = "Oldtimer", string model = "RustBucket")
    {
        return new Car(
            carId: ObjectId.GenerateNewId().ToString(),
            brand: brand,
            modell: model,
            price: 1_500.00,
            baseHorsepower: 45,
            currentHorsepower: 45,
            baseWeight: 900.0,
            currentWeight: 900.0,
            initialParts: new List<TuningPart>()
            {
                new Engine(ObjectId.GenerateNewId().ToString(), name: "Lawnmower Engine", price: 0, weight: 80, isInstalled: true, color: "Rusty Brown", fuelConsumption: 5.0, horsePower: 45),
                new Brake(ObjectId.GenerateNewId().ToString(), name: "Old Drum Brakes", price: 0, weight: 15.0, isInstalled: true, color: "Grey", brakeforce: 30),
                new Frontspoiler(ObjectId.GenerateNewId().ToString(), name: "Plastic Lip", price: 0, weight: 2, isInstalled: true, color: "Black", downforce: 5),
                new Heckspoiler(ObjectId.GenerateNewId().ToString(), name: "Small Ducktail", price: 0, weight: 3, isInstalled: true, color: "Black", downforce: 5),
                new Tire(ObjectId.GenerateNewId().ToString(), name: "Thin Eco Tire", price: 0, weight: 4, isInstalled: true, color: "Black", Type.Race, thickness: 3, grip: 10),
                new Rimm(ObjectId.GenerateNewId().ToString(), name: "Steel Rims", price: 0, weight: 12, isInstalled: true, color: "Silver", diameter: 13)
            }
        );
    }
}
 