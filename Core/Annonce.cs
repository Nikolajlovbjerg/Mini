using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core;

public class Annonce
{
    [BsonId]
    public int AnonnceId { get; set; }
    
    public int BrugerId { get; set; }
    
    public string? Title { get; set; } 
    
    public string? Description { get; set; } 
    
    public double Price { get; set; }
    
    public string? Category { get; set; } 
    
    public string? Status { get; set; } 
    
    public string? ImageUrl { get; set; }

    [BsonElement("SælgerId")]
    public int SaelgerId { get; set; }
    
    public string? Location { get; set; } 
    
    public List<Anmodning>? Anmodninger { get; set; }
}