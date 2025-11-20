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
//Finder den sidste annonce for at bestemme det næste AnonnceId
        var lastAnnonce = aAnnonce
            .Find(Builders<Annonce>.Filter.Empty)
            .SortByDescending(a => a.AnonnceId)
            .Limit(1)
            .FirstOrDefault();

//Tildeler +1 til det sidste AnonnceId eller 1 hvis der ikke er nogen annoncer
        annonce.AnonnceId = (lastAnnonce?.AnonnceId ?? 0) + 1;

//Indsætter den nye annonce i aAnnonce-collectionen
        aAnnonce.InsertOne(annonce);
    }
    
//Opdaterer en eksisterende annonce i databasen
    public void Update(Annonce annonce)
    {
        // Finder det dokument i databasen, hvor AnonnceId matcher det annonce-objekt vi vil opdatere
        var filter = Builders<Annonce>.Filter.Eq(a => a.AnonnceId, annonce.AnonnceId);
        // Erstat det gamle dokument med det nye annonce-objekt
        aAnnonce.ReplaceOne(filter, annonce);
    }

//Delete-motode til at slette en annonce baseret på dens AnonnceId
    public void Delete(int id)
    {
        aAnnonce.DeleteOne(a => a.AnonnceId == id);
    }
}