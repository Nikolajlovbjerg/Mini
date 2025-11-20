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
        //Henter informationen som DB skal bruge som navn på DB og Navn på Collection og con string
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

        //Ingen filter henter alle documenter
        //Sorter dem så den med højste id kommer først
        //Vælger kun den første 
        //Retunere enten det dokument der blev fundet eller null
        //Øger id værdien med 1 så der altid vil være et nyt id
        //Indsætter den i dokumentet

        //Bruges til at fjerne object string uden problemer for nu
    }

    public void Update(Annonce annonce)
    {
        var filter = Builders<Annonce>.Filter.Eq(a => a.AnonnceId, annonce.AnonnceId);
        aAnnonce.ReplaceOne(filter, annonce);

        //Finder det dokument hvor det id der er i DB matcher det id du vil opdatere/ændre på
        //Og så ændre hele dokumentet med objektet 
    }

    public void Delete(int id)
    {
        aAnnonce.DeleteOne(a => a.AnonnceId == id);

        //...aAnnonce er = IMongoCllection<...> //Collectionen\\
        // DeleteOne finder det første dokument hvor brugerid == id
        //Så bliver det slettet
    }

}