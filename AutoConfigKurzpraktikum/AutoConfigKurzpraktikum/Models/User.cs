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

    public List<Auto> Cars { get; set; } = new List<Auto>();

}