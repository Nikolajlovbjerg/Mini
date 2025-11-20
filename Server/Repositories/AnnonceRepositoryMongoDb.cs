using MongoDB.Driver; // Importerer MongoDB-driveren for at interagere med MongoDB-databasen
using Core; // Importerer kernefunktionaliteten, herunder Annonce-klassen
using Server.PW1; // Importerer PASSWORD-klassen for at få adgang til adgangskoden

namespace Server.Repositories;

//Implementerer IAnnonceRepository interfacet for at håndtere annonce-data i MongoDB
public class AnnonceRepositoryMongoDb : IAnnonceRepository
{
//Repræsentation af MongoDB-collectionen for annoncer
    private readonly IMongoCollection<Annonce> aAnnonce;

//Konstrukter der opretter forbindelse til MongoDB og initialiserer aAnnonce-collectionen
    public AnnonceRepositoryMongoDb()
    {
//Opretter MongoDB Uri med brugernavn og adgangskode
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri); // Opretter en MongoDB-klient
        var database = client.GetDatabase("Genbrug"); // Får adgang til "Genbrug" databasen
        aAnnonce = database.GetCollection<Annonce>("Annonce"); //Vælger "Annonce" collectionen
    }

//Henter alle annoncer fra databasen
    public List<Annonce> GetAll()
    {
//Finder alle dokumenter i aAnnonce-collectionen og returnerer dem som en liste
        return aAnnonce.Find(_  => true).ToList();
    }

//Henter en annonce baseret på dens AnonnceId
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
        //Og så ændre hele dokumentet med objektet (Erstat det gamle dokument med det nye annonce-objekt)

    }

    //Delete-motode til at slette en annonce baseret på dens AnonnceId
    public void Delete(int id)
    {
        aAnnonce.DeleteOne(a => a.AnonnceId == id);

        //...aAnnonce er = IMongoCllection<...> //Collectionen\\
        // DeleteOne finder det første dokument hvor brugerid == id
        //Så bliver det slettet
    }
}