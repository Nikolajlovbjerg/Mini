using Core;
using MongoDB.Driver;
using Server.PW1;

namespace Server.Repositories;

public class AnmodningsRepository : IAnmodningRepo
{
    private readonly IMongoCollection<Anmodning> _AnmodCollection;
    private readonly IMongoCollection<Annonce> aAnnonce;
    private readonly IMongoCollection<MineIndkob> mkob;

    //Siger mere eller mindre at "mkob" er collectionen med dokumenter af typen (MineInkob)

    public AnmodningsRepository()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        _AnmodCollection = database.GetCollection<Anmodning>("Anmodning");
        aAnnonce = database.GetCollection<Annonce>("Annonce");
        mkob = database.GetCollection<MineIndkob>("mineindkob");

        //Henter informationen som DB skal bruge som navn på DB og Navn på Collection og con string
    }

    public List<Anmodning> GetAll()
    {
        return _AnmodCollection.Find(_ => true).ToList(); //Henter alle dokumenter fra DB og konverter det til en liste
    }

    public List<Anmodning> GetByAnnonceId(int annonceId)
    {
        return _AnmodCollection
            .Find(a => a.AnnonceId == annonceId)
            .ToList();

        //filtere i collectionen så den kun henter de dokumenter hvor Id == Id og derefter konvater det til en liste
        //og Retunere det
    }

    public void Add(Anmodning anmod)
    { 
        var lastAnmod = _AnmodCollection
           .Find(Builders<Anmodning>.Filter.Empty)
           .SortByDescending(a => a.AnmodningId)
           .Limit(1)
           .FirstOrDefault();
        anmod.AnmodningId = (lastAnmod?.AnmodningId ?? 0) + 1;


        _AnmodCollection.InsertOne(anmod);

        //Ingen filter henter alle documenter
        //Sorter dem så den med højste id kommer først
        //Vælger kun den første 
        //Retunere enten det dokument der blev fundet eller null
        //Øger id værdien med 1 så der altid vil være et nyt id
        //Indsætter den i dokumentet

        //Bruges til at fjerne object string uden problemer for nu
    }
    public void AcceptAnmodning(int annonceId, int anmodningId)
    {
       
        var anmodninger = _AnmodCollection.Find(a => a.AnnonceId == annonceId).ToList();

        foreach (var a in anmodninger)
        {
            if (a.AnmodningId == anmodningId)
                a.Status = "accepteret"; 
            else if (a.Status == "pending")
                a.Status = "afvist"; 
        }

        
        foreach (var a in anmodninger)
        {
            _AnmodCollection.ReplaceOne(x => x.AnmodningId == a.AnmodningId, a);
        }

        //filtere i collectionen så den kun henter de dokumenter hvor Id == Id og derefter konvater det til en liste
        //Og for hvert element køre den et if statement
        //If statementet siger at hvis den anmodnig der har anmodningId er blevet accepteret så opdatere den status til accepteret på den ene og afvist på de andre
        //Og så ændre den i DataBasen(Kunne måske have brugt update i stedet for replace)
    }
    public void AcceptAndMove(int annonceId, int anmodningId)
    {
       
        var annonce = aAnnonce.Find(a => a.AnonnceId == annonceId).FirstOrDefault();
        if (annonce == null) return;

        //Henter annoncen med annonceId
        //Hvis den ikke kan finde noget retunere den null(Ingenting)

        
        var anmod = _AnmodCollection.Find(a => a.AnmodningId == anmodningId).FirstOrDefault();
        if (anmod == null) return;

        //Henter den specifikke anmodning
        //Hvis den ikke kan finde noget retunere den null(Ingenting)


        var mineIndkob = new MineIndkob
        {
            AnnonceId = annonce.AnonnceId,
            BrugerId = anmod.BuyerId, 
            Title = annonce.Title,
            Description = annonce.Description,
            Price = annonce.Price,
            Category = annonce.Category,
            ImageUrl = annonce.ImageUrl,
            Location = annonce.Location,
            SaelgerId = annonce.SaelgerId
        };
        //Opretter et ny objekt af typen MineIndkob
        //Og fylder det med oplysninger fra annonce og anmod

        //Det er der fordi vi vil gerne ende med "flytte" dataen fra annoncer til købte ting
        //Og det gør vi ved at kopiere relevante oplysninger til mineIndkob

        //Så det omhandler at placere noget data fra et sted og fjerne det fra det nuværende sted

        
        

 
        var last = mkob.Find(Builders<MineIndkob>.Filter.Empty)
                      .SortByDescending(m => m.KobId)
                      .Limit(1)
                      .FirstOrDefault();
        mineIndkob.KobId = (last?.KobId ?? 0) + 1;

        mkob.InsertOne(mineIndkob);

        //Ingen filter henter alle documenter
        //Sorter dem så den med højste id kommer først
        //Vælger kun den første 
        //Retunere enten det dokument der blev fundet eller null
        //Øger id værdien med 1 så der altid vil være et nyt id
        //Indsætter den i dokumentet

        //Bruges til at fjerne object string uden problemer for nu

        
        aAnnonce.DeleteOne(a => a.AnonnceId == annonceId);
        //...aAnnonce er = IMongoCllection<...> //Collectionen\\
        // DeleteOne finder det første dokument hvor brugerid == id
        //Så bliver det slettet


        
        _AnmodCollection.DeleteMany(a => a.AnnonceId == annonceId);
        //Samme som før men sletter alle i stedet
    }
}