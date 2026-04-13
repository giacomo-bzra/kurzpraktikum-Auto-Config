namespace AutoConfigKurzpraktikum.Service;
using AutoConfigKurzpraktikum.Models.Parts;
using AutoConfigKurzpraktikum.Models;
using MongoDB.Bson;
public class PartsCollection
{
     public static IReadOnlyList<TuningPart> All => _parts.AsReadOnly();
     public static List<Tire> AllTires => _parts.OfType<Tire>().ToList();
     public static List<Brake> AllBrakes => _parts.OfType<Brake>().ToList();
     public static List<Frontspoiler> AllFrontspoilers => _parts.OfType<Frontspoiler>().ToList();
     public static List<Heckspoiler> AllHeckspoilers => _parts.OfType<Heckspoiler>().ToList();
     public static List<Rimm> AllRimms => _parts.OfType<Rimm>().ToList();
     public static List<Engine> AllEngines => _parts.OfType<Engine>().ToList();

    private static readonly List<TuningPart> _parts = new()
    {
        // ── Engines ──────────────────────────────────────────────────────────
        new Engine(ObjectId.GenerateNewId().ToString(),
            "Sport-Motor 400 PS",   price: 8_500,  weight: 180, isInstalled: false,
            color: "Silber",        fuelConsumption: 9.5),

        new Engine(ObjectId.GenerateNewId().ToString(),
            "Turbo-Motor 600 PS",   price: 18_000, weight: 210, isInstalled: false,
            color: "Schwarz",       fuelConsumption: 13.0),
        
        new Engine(ObjectId.GenerateNewId().ToString(),
            name: "V8-Biturbo 800 PS", price: 35_000, weight: 240, isInstalled: false,
            color: "Gold/Schwarz", fuelConsumption: 18.5),

        new Engine(ObjectId.GenerateNewId().ToString(),
            name: "Elektro-Antrieb Unit X", price: 22_500, weight: 150, isInstalled: false,
            color: "Neon-Blau", fuelConsumption: 0.0),

        // ── Brakes ───────────────────────────────────────────────────────────
        new Brake(ObjectId.GenerateNewId().ToString(),
            "Sport-Bremse",         price: 1_200,  weight: 22,  isInstalled: false,
            color: "Rot",           brakeforce: 850),

        new Brake(ObjectId.GenerateNewId().ToString(),
            "Carbon-Keramik-Bremse",price: 4_500,  weight: 14,  isInstalled: false,
            color: "Gelb",          brakeforce: 1_200),
        
        new Brake(ObjectId.GenerateNewId().ToString(),
            name: "Keramik-Rennbremse Ultra", price: 6_800, weight: 12, isInstalled: false,
            color: "Orange", brakeforce: 1_500),

        new Brake(ObjectId.GenerateNewId().ToString(),
            name: "Standard-Ersatzbremse", price: 450, weight: 25, isInstalled: false,
            color: "Grau", brakeforce: 600),

        // ── Frontspoiler ─────────────────────────────────────────────────────
        new Frontspoiler(ObjectId.GenerateNewId().ToString(),
            "Frontlippe Carbon",    price: 650,    weight: 3.5, isInstalled: false,
            color: "Carbon",        downforce: 40),

        new Frontspoiler(ObjectId.GenerateNewId().ToString(),
            "Breiter Front-Splitter",price: 1_100, weight: 5.0, isInstalled: false,
            color: "Weiß",          downforce: 90),
        
        new Frontspoiler(ObjectId.GenerateNewId().ToString(),
            name: "Aero-Dynamic Lippe", price: 850, weight: 2.8, isInstalled: false,
            color: "Schwarz-Matt", downforce: 65),

        new Frontspoiler(ObjectId.GenerateNewId().ToString(),
            name: "Street-Style Splitter", price: 400, weight: 4.5, isInstalled: false,
            color: "Wagenfarbe", downforce: 30),

        // ── Heckspoiler ──────────────────────────────────────────────────────
        new Heckspoiler(ObjectId.GenerateNewId().ToString(),
            "Heckspoiler GT",       price: 900,    weight: 4.2, isInstalled: false,
            color: "Schwarz",       downforce: 120),

        new Heckspoiler(ObjectId.GenerateNewId().ToString(),
            "Racing-Wing",          price: 2_200,  weight: 6.8, isInstalled: false,
            color: "Carbon",        downforce: 250),
        
        new Heckspoiler(ObjectId.GenerateNewId().ToString(),
            name: "Dragster-Wing High-Downforce", price: 2_100, weight: 6.5, isInstalled: false,
            color: "Carbon", downforce: 350),

        new Heckspoiler(ObjectId.GenerateNewId().ToString(),
            name: "Dezente Abrisskante", price: 250, weight: 1.2, isInstalled: false,
            color: "Schwarz-Glanz", downforce: 15),

        // ── Rims ─────────────────────────────────────────────────────────────
        new Rimm(ObjectId.GenerateNewId().ToString(),
            "Alufelge 18\"",        price: 800,    weight: 9.5, isInstalled: false,
            color: "Silber",        diameter: 18),

        new Rimm(ObjectId.GenerateNewId().ToString(),
            "Schmiedefelge 20\"",   price: 2_400,  weight: 8.0, isInstalled: false,
            color: "Schwarz matt",  diameter: 20),
        
        new Rimm(ObjectId.GenerateNewId().ToString(),
            name: "Carbon-Fiber Ultra Light 21\"", price: 4_500, weight: 5.2, isInstalled: false,
            color: "Carbon-Sichtgewebe", diameter: 21),

        new Rimm(ObjectId.GenerateNewId().ToString(),
            name: "Classic Deep-Dish 17\"", price: 650, weight: 11.5, isInstalled: false,
            color: "Chrom", diameter: 17),

        new Rimm(ObjectId.GenerateNewId().ToString(),
            name: "Magnesium-Rennfelge 19\"", price: 3_200, weight: 6.8, isInstalled: false,
            color: "Gold", diameter: 19),

        // ── Tires ────────────────────────────────────────────────────────────
        new Tire(ObjectId.GenerateNewId().ToString(),
            "Slick Race-Reifen",    price: 600,    weight: 7.0, isInstalled: false,
            color: "Schwarz",       tireType: Models.Parts.Type.Race,   thickness: 25, 40),

        new Tire(ObjectId.GenerateNewId().ToString(),
            "Drift-Reifen",         price: 450,    weight: 8.5, isInstalled: false,
            color: "Schwarz",       tireType: Models.Parts.Type.Drift,  thickness: 30, 10),

        new Tire(ObjectId.GenerateNewId().ToString(),
            "Offroad-Reifen",       price: 500,    weight: 12.0,isInstalled: false,
            color: "Schwarz",       tireType: Models.Parts.Type.Offroad,thickness: 45, 35),
        
        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Allwetter-Performance", price: 250, weight: 9.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Drift, thickness: 35, 25),

        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Pro-Rain Wet-Slick", price: 550, weight: 7.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Race, thickness: 28, 50),

        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Extreme-Grip Winter", price: 320, weight: 10.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Offroad, thickness: 40, 60),
        
        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Derby-Tires", price: 550, weight: 7.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Derby, thickness: 28, 80),

        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Relley-Tires", price: 320, weight: 10.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Ralley, 60, 35),
        
        new Tire(ObjectId.GenerateNewId().ToString(),
            name: "Drag-Tires", price: 320, weight: 10.5, isInstalled: false,
            color: "Schwarz", tireType: Models.Parts.Type.Drag, 60, 100),
    };
}



   