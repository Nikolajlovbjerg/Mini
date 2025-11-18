using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Core;

public class Bruger
{
    [BsonId]
    public int BrugerId { get; set; } 
    
    public string Name { get; set; } 
    
    public string Email { get; set; } 
    
    public string Phone { get; set; } 
    
    public string Address { get; set; }

    public string Password { get; set; }
}