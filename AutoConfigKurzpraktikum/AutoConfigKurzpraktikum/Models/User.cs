using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoConfigKurzpraktikum.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }

    public List<Car> Cars { get; set; } = new List<Car>();

    public User(string userId,string Username, string Password, decimal Balance)
    {
        this.UserId = userId;
        this.Username = Username;
        this.Password = Password;
        this.Balance = Balance;
    }

    public void AddCar(Car newCar)
    {
        if (newCar == null)
        {
            this.Cars.Add(newCar);
        }
    }
}