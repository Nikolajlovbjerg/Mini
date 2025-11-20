using MongoDB.Driver;
using Core;
using Server.PW1;

namespace Server.Repositories;

public class AnnonceRepositoryMongoDb : IAnnonceRepository
{
    private readonly IMongoCollection<Annonce> aAnnonce;

    public AnnonceRepositoryMongoDb()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        aAnnonce = database.GetCollection<Annonce>("Annonce");
    }

    public List<Annonce> GetAll()
    {
        return aAnnonce.Find(_  => true).ToList();
    }

    public void Add(Annonce annonce)
    {
        var lastAnnonce = aAnnonce
            .Find(Builders<Annonce>.Filter.Empty)
            .SortByDescending(a => a.AnonnceId)
            .Limit(1)
            .FirstOrDefault();

        annonce.AnonnceId = (lastAnnonce?.AnonnceId ?? 0) + 1;

        aAnnonce.InsertOne(annonce);
    }
    
    public void Update(Annonce annonce)
    {
        var filter = Builders<Annonce>.Filter.Eq(a => a.AnonnceId, annonce.AnonnceId);
        aAnnonce.ReplaceOne(filter, annonce);
    }

    public void Delete(int id)
    {
        aAnnonce.DeleteOne(a => a.AnonnceId == id);
    }
    /*Dette er en delete-metode i repository’et. Den modtager et id som parameter og 
     fortæller MongoDB at slette det dokument(annonce) i aAnnonce-collectionen, hvor AnonnceId matcher det givne id */
}