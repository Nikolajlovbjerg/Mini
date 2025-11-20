using Core;
using MongoDB.Driver;
using Server.PW1;

namespace Server.Repositories;

public class AnmodningsRepository : IAnmodningRepo
{
    private readonly IMongoCollection<Anmodning> _AnmodCollection;
    private readonly IMongoCollection<Annonce> aAnnonce;
    private readonly IMongoCollection<MineIndkob> mkob;

    public AnmodningsRepository()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        _AnmodCollection = database.GetCollection<Anmodning>("Anmodning");
        aAnnonce = database.GetCollection<Annonce>("Annonce");
        mkob = database.GetCollection<MineIndkob>("mineindkob");
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

        // Opdater alle �ndringer tilbage i databasen
        foreach (var a in anmodninger)
        {
            _AnmodCollection.ReplaceOne(x => x.AnmodningId == a.AnmodningId, a);
        }
    }
    public void AcceptAndMove(int annonceId, int anmodningId)
    {
        //Hent annonce
        var annonce = aAnnonce.Find(a => a.AnonnceId == annonceId).FirstOrDefault();
        if (annonce == null) return;

        // Hent accepteret anmodning
        var anmod = _AnmodCollection.Find(a => a.AnmodningId == anmodningId).FirstOrDefault();
        if (anmod == null) return;

        // Opret MineIndk�b objekt
        var mineIndkob = new MineIndkob
        {
            AnnonceId = annonce.AnonnceId,
            BrugerId = anmod.BuyerId, // k�beren
            Title = annonce.Title,
            Description = annonce.Description,
            Price = annonce.Price,
            Category = annonce.Category,
            ImageUrl = annonce.ImageUrl,
            Location = annonce.Location,
            SaelgerId = annonce.SaelgerId
        };

        //Insert i MineIndk�b collection
        

        // Auto-increment id (samme logik som f�r)
        var last = mkob.Find(Builders<MineIndkob>.Filter.Empty)
                      .SortByDescending(m => m.KobId)
                      .Limit(1)
                      .FirstOrDefault();
        mineIndkob.KobId = (last?.KobId ?? 0) + 1;

        mkob.InsertOne(mineIndkob);

        //Slet annoncen fra Annonce collection
        aAnnonce.DeleteOne(a => a.AnonnceId == annonceId);

        //Slet alle anmodninger for annoncen
        _AnmodCollection.DeleteMany(a => a.AnnonceId == annonceId);
    }
}