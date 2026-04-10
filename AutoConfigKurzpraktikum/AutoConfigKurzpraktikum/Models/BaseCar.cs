using MongoDB.Bson;

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
        );
    }
}