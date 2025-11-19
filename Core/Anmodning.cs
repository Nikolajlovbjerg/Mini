using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core;

public class Anmodning
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? MongoId { get; set; }
    public int AnmodningId { get; set; }
    public int AnnonceId { get; set; }
    public int BuyerId { get; set; }
    public int BrugerId { get; set; }

    public DateTime Date { get; set; }
    public string Status { get; set; } = "pending";
    public DateTime Created { get; set; } = DateTime.UtcNow;
}