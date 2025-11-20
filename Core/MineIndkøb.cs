using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class MineIndkob
    {
        [BsonId]
        public int KobId { get; set; } 
        public int AnnonceId { get; set; }
        public int BrugerId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }

        [BsonElement("SælgerId")]
        public int SaelgerId { get; set; }
        public DateTime KobtDato { get; set; } = DateTime.UtcNow;
    }
}
