using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core;

public class MineIndkøb
{
    [BsonId]
    public int Id { get; set; }

    public int? AnnonceId { get; set; }
    public int? BuyerId { get; set; }
    public int? SælgerId { get; set; }

    public string? Status { get; set; } = "accepteret";
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
