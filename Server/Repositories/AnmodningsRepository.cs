using Core;
using MongoDB.Driver;
using Server.PW1;

namespace Server.Repositories;

public class AnmodningsRepository : IAnmodningRepo
{
    private readonly IMongoCollection<Anmodning> _AnmodCollection;

    public AnmodningsRepository()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        _AnmodCollection = database.GetCollection<Anmodning>("Anmodning");
    }

    public List<Anmodning> GetAll()
    {
        return _AnmodCollection.Find(_ => true).ToList();
    }

    public List<Anmodning> GetByAnnonceId(int annonceId)
    {
        return _AnmodCollection
            .Find(a => a.AnnonceId == annonceId)
            .ToList();
    }

    public void Add(Anmodning anmod)
    {
        // lav manuelt autoincrement ID (samme stil som jeres andre repos)
        var lastAnmod = _AnmodCollection
           .Find(Builders<Anmodning>.Filter.Empty)
           .SortByDescending(a => a.AnmodningId)
           .Limit(1)
           .FirstOrDefault();
        anmod.AnmodningId = (lastAnmod?.AnmodningId ?? 0) + 1;
        

        _AnmodCollection.InsertOne(anmod);
    }
    public void AcceptAnmodning(int annonceId, int anmodningId)
    {
        // Hent alle anmodninger for annoncen
        var anmodninger = _AnmodCollection.Find(a => a.AnnonceId == annonceId).ToList();

        foreach (var a in anmodninger)
        {
            if (a.AnmodningId == anmodningId)
                a.Status = "accepteret"; // Accepter den valgte
            else if (a.Status == "pending")
                a.Status = "afvist"; // Afvis de andre pending
        }

        // Opdater alle ændringer tilbage i databasen
        foreach (var a in anmodninger)
        {
            _AnmodCollection.ReplaceOne(x => x.AnmodningId == a.AnmodningId, a);
        }
    }
}