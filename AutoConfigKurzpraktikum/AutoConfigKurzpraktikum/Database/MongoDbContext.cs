using AutoConfigKurzpraktikum.Models;
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    
    public IMongoCollection<User> UsersCollection => _database.GetCollection<User>("Users");
    public IMongoCollection<Car> CarsCollection => _database.GetCollection<Car>("Cars");

  
    public List<User> GetAllUsers()
    {
        return UsersCollection.Find(Builders<User>.Filter.Empty).ToList();
    }
    
    public List<Car> GetAllCars()
    {
        return CarsCollection.Find(Builders<Car>.Filter.Empty).ToList();
    }
    
    
}