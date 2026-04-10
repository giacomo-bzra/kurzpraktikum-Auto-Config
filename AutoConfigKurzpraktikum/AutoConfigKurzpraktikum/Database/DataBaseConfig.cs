using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Models.Parts;
using MongoDB.Bson.Serialization;

namespace AutoConfigKurzpraktikum;

public static class DataBaseConfig
{
    public static void RegisterClassMaps()
    {
        
        BsonClassMap.RegisterClassMap<TuningPart>(cm => {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
        BsonClassMap.RegisterClassMap<Engine>();
        BsonClassMap.RegisterClassMap<Heckspoiler>();
        BsonClassMap.RegisterClassMap<Brake>();
        BsonClassMap.RegisterClassMap<Frontspoiler>();
        
    }
}