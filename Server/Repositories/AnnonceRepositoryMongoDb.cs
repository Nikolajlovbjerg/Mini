using MongoDB.Driver;
using Core;
using Server.PW1;

namespace Server.Repositories;

public class AnnonceRepositoryMongoDb : IAnnonceRepo
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
        return aAnnonce.Find(_ => true).ToList();
    }

    public void Add(Annonce annonce)
    {
        var lastAnnonce = aAnnonce
            .Find(Builders<Annonce>.Filter.Empty)
            .SortByDescending(a => a.AnnonceId)
            .Limit(1)
            .FirstOrDefault();

        annonce.AnnonceId = (lastAnnonce?.AnnonceId ?? 0) + 1;

        aAnnonce.InsertOne(annonce);
    }
}