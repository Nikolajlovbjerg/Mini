using MongoDB.Driver;
using Core;

namespace Server.Repositories.TEST;

public class AnnonceRepositoryMongoDb : IAnnonceRepository
{
    private readonly IMongoCollection<Annonce> aAnnonce;

    public AnnonceRepositoryMongoDb()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("genbrug");
        aAnnonce = database.GetCollection<Annonce>("annonce");
    }

    public List<Annonce> GetAll()
    {
        return aAnnonce.Find(_  => true).ToList();
    }

    public void Add(Annonce annonce)
    {
        annonce.AnonnceId = new Random().Next(1, int.MaxValue);
        aAnnonce.InsertOne(annonce);
    }
}