using MongoDB.Driver;
using MongoDB.Bson;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Models.Parts;

namespace AutoConfigKurzpraktikum;

public static class DbSeeder
{
    public static async Task SeedAll(IMongoDatabase database)
    {
        await SeedParts(database);
        await SeedCars(database);
    }

    public static async Task SeedParts(IMongoDatabase database)
    {
        var partsCollection = database.GetCollection<TuningPart>("Parts");

        if (await partsCollection.CountDocumentsAsync(new BsonDocument()) > 0) return;

        var parts = new List<TuningPart>
        {
            // ── Engines ──────────────────────────────────────────────────────────
            new Engine(ObjectId.GenerateNewId().ToString(), "Sport-Motor 400 PS", 8500, 180, false, "Silber", 9.5, 400),
            new Engine(ObjectId.GenerateNewId().ToString(), "Turbo-Motor 600 PS", 18000, 210, false, "Schwarz", 13.0,
                600),
            new Engine(ObjectId.GenerateNewId().ToString(), "V8-Biturbo 800 PS", 35000, 240, false, "Gold/Schwarz",
                18.5, 800),
            new Engine(ObjectId.GenerateNewId().ToString(), "Elektro-Antrieb Unit X", 22500, 150, false, "Neon-Blau",
                0.0, 450),
            new Engine(ObjectId.GenerateNewId().ToString(), "Standart V6", 0, 300, false, "Black", 10.5, 100),
            new Engine(ObjectId.GenerateNewId().ToString(), "Lawnmower Engine", 0, 80, false, "Rusty Brown", 5.0, 45),

            // ── Brakes ───────────────────────────────────────────────────────────
            new Brake(ObjectId.GenerateNewId().ToString(), "Sport-Bremse", 1200, 22, false, "Rot", 850),
            new Brake(ObjectId.GenerateNewId().ToString(), "Carbon-Keramik-Bremse", 4500, 14, false, "Gelb", 1200),
            new Brake(ObjectId.GenerateNewId().ToString(), "Keramik-Rennbremse Ultra", 6800, 12, false, "Orange", 1500),
            new Brake(ObjectId.GenerateNewId().ToString(), "Standard-Ersatzbremse", 450, 25, false, "Grau", 600),
            new Brake(ObjectId.GenerateNewId().ToString(), "Basis Lippe", 0, 5.0, false, "Black", 100),
            new Brake(ObjectId.GenerateNewId().ToString(), "Old Drum Brakes", 0, 15.0, false, "Grey", 30),

            // ── Frontspoiler ─────────────────────────────────────────────────────
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Frontlippe Carbon", 650, 3.5, false, "Carbon", 40),
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Breiter Front-Splitter", 1100, 5.0, false, "Weiß",
                90),
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Aero-Dynamic Lippe", 850, 2.8, false, "Schwarz-Matt",
                65),
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Street-Style Splitter", 400, 4.5, false,
                "Wagenfarbe", 30),
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Basic Front", 0, 10, false, "Black", 70),
            new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Plastic Lip", 0, 2, false, "Black", 5),

            // ── Heckspoiler ──────────────────────────────────────────────────────
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Heckspoiler GT", 900, 4.2, false, "Schwarz", 120),
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Racing-Wing", 2200, 6.8, false, "Carbon", 250),
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Dragster-Wing High-Downforce", 2100, 6.5, false,
                "Carbon", 350),
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Dezente Abrisskante", 250, 1.2, false,
                "Schwarz-Glanz", 150),
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Basis Heck", 0, 10, false, "Black", 70),
            new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Small Ducktail", 0, 3, false, "Black", 5),

            // ── Rims ─────────────────────────────────────────────────────────────
            new Rimm(ObjectId.GenerateNewId().ToString(), "Alufelge 18\"", 800, 9.5, false, "Silber", 18),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Schmiedefelge 20\"", 2400, 8.0, false, "Schwarz matt", 20),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Carbon-Fiber Ultra Light 21\"", 4500, 5.2, false,
                "Carbon-Sichtgewebe", 21),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Classic Deep-Dish 17\"", 650, 11.5, false, "Chrom", 17),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Magnesium-Rennfelge 19\"", 3200, 6.8, false, "Gold", 19),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Basis Rimm", 0, 5, false, "Black", 50),
            new Rimm(ObjectId.GenerateNewId().ToString(), "Steel Rims", 0, 12, false, "Silver", 13),

            // ── Tires ────────────────────────────────────────────────────────────
            new Tire(ObjectId.GenerateNewId().ToString(), "Slick Race-Reifen", 600, 7.0, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Race, 25, 40),
            new Tire(ObjectId.GenerateNewId().ToString(), "Drift-Reifen", 450, 8.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Drift, 30, 10),
            new Tire(ObjectId.GenerateNewId().ToString(), "Offroad-Reifen", 500, 12.0, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Offroad, 45, 35),
            new Tire(ObjectId.GenerateNewId().ToString(), "Allwetter-Performance", 250, 9.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Drift, 35, 25),
            new Tire(ObjectId.GenerateNewId().ToString(), "Pro-Rain Wet-Slick", 550, 7.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Race, 28, 50),
            new Tire(ObjectId.GenerateNewId().ToString(), "Extreme-Grip Winter", 320, 10.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Offroad, 40, 60),
            new Tire(ObjectId.GenerateNewId().ToString(), "Derby-Tires", 550, 7.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Derby, 28, 80),
            new Tire(ObjectId.GenerateNewId().ToString(), "Relley-Tires", 320, 10.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Ralley, 60, 35),
            new Tire(ObjectId.GenerateNewId().ToString(), "Drag-Tires", 320, 10.5, false, "Schwarz",
                AutoConfigKurzpraktikum.Models.Parts.Type.Drag, 60, 100),
            new Tire(ObjectId.GenerateNewId().ToString(), "Basic Tire", 0, 5, false, "Black",
                AutoConfigKurzpraktikum.Models.Parts.Type.Race, 5, 15),
            new Tire(ObjectId.GenerateNewId().ToString(), "Thin Eco Tire", 0, 4, false, "Black",
                AutoConfigKurzpraktikum.Models.Parts.Type.Race, 3, 10)
        };

        await partsCollection.InsertManyAsync(parts);
    }

    public static async Task SeedCars(IMongoDatabase database)
    {
        var carCollection = database.GetCollection<Car>("Cars");
        if (await carCollection.CountDocumentsAsync(new BsonDocument()) > 0) return;

        var cars = new List<Car>
        {
            new Car(
                carId: ObjectId.GenerateNewId().ToString(),
                brand: "BMW",
                modell: "M3",
                price: 45000.00,
                baseHorsepower: 300,
                currentHorsepower: 300,
                baseWeight: 1500.0,
                currentWeight: 1500.0,
                initialParts: new List<TuningPart>
                {
                    new Engine(ObjectId.GenerateNewId().ToString(), "Standart V6", 0, 300, true, "Black", 10.5, 100),
                    new Brake(ObjectId.GenerateNewId().ToString(), "Basis Lippe", 0, 5.0, true, "Black", 100),
                    new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Basic Front", 0, 10, true, "Black", 70),
                    new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Basis Heck", 0, 10, true, "Black", 70),
                    new Tire(ObjectId.GenerateNewId().ToString(), "Basic Tire", 0, 5, true, "Black",
                        AutoConfigKurzpraktikum.Models.Parts.Type.Race, 5, 15),
                    new Rimm(ObjectId.GenerateNewId().ToString(), "Basis Rimm", 0, 5, true, "Black", 50)
                },
                color:  "#4682B4"
            ),
            new Car(
                carId: ObjectId.GenerateNewId().ToString(),
                brand: "Oldtimer",
                modell: "RustBucket",
                price: 1500.00,
                baseHorsepower: 45,
                currentHorsepower: 45,
                baseWeight: 900.0,
                currentWeight: 900.0,
                initialParts: new List<TuningPart>
                {
                    new Engine(ObjectId.GenerateNewId().ToString(), "Lawnmower Engine", 0, 80, true, "Rusty Brown", 5.0,
                        45),
                    new Brake(ObjectId.GenerateNewId().ToString(), "Old Drum Brakes", 0, 15.0, true, "Grey", 30),
                    new Frontspoiler(ObjectId.GenerateNewId().ToString(), "Plastic Lip", 0, 2, true, "Black", 5),
                    new Heckspoiler(ObjectId.GenerateNewId().ToString(), "Small Ducktail", 0, 3, true, "Black", 5),
                    new Tire(ObjectId.GenerateNewId().ToString(), "Thin Eco Tire", 0, 4, true, "Black",
                        AutoConfigKurzpraktikum.Models.Parts.Type.Race, 3, 10),
                    new Rimm(ObjectId.GenerateNewId().ToString(), "Steel Rims", 0, 12, true, "Silver", 13)
                },
                color:"#8B4513"
            )
        };
        await carCollection.InsertManyAsync(cars);
    }
}