using System.Collections.Generic;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Models.Parts;
using MongoDB.Driver;

namespace AutoConfigKurzpraktikum;

public static class MongoDbContext
{
    private static MongoClient _mongoClient;
    private static IMongoDatabase _database;
    private static IMongoCollection<Car> _cars;
    private static IMongoCollection<User> _users;

    public static void LoadDatabase(string connectionString, string databaseName)
    {
        _mongoClient = new MongoClient(connectionString);
        _database = _mongoClient.GetDatabase(databaseName);
        _cars = _database.GetCollection<Car>("Cars");
        _users = _database.GetCollection<User>("Users");
    }

    public static List<Car> GetCars()
    {
        return _cars.Find(car => true).ToList();
    }

    public static List<User> GetUsers()
    {
        return _users.Find(user => true).ToList();
      
    }
  
    public static void SaveCar(Car car)
    {
        if (_cars.Find(c => c.CarId == car.CarId).Any()) _cars.ReplaceOne(c => c.CarId == car.CarId, car);
        else _cars.InsertOne(car);
    }
}
