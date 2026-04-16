using System.Configuration;
using System.Data;
using System.Windows;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Models.Parts;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        if (!BsonClassMap.IsClassMapRegistered(typeof(TuningPart)))
        {
            BsonClassMap.RegisterClassMap<TuningPart>(cm => {
                cm.AutoMap();
                cm.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<Engine>();
            BsonClassMap.RegisterClassMap<Brake>();
            BsonClassMap.RegisterClassMap<Tire>();
            BsonClassMap.RegisterClassMap<Rimm>();
            BsonClassMap.RegisterClassMap<Frontspoiler>();
            BsonClassMap.RegisterClassMap<Heckspoiler>();
        }
        
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("AutoConfig");
        
        try
        {
            await DbSeeder.SeedAll(database);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show($"Fehler beim Datenbank-Seeding: {ex.Message}");
        }
    }
}