using Core;
using MongoDB.Driver;
using Server.PW1;

namespace Server.Repositories
{
    public class BrugerRepo : IBrugerRepo
    {
        private readonly IMongoCollection<Bruger> brugerCollection;

        public BrugerRepo()
        {
            var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            var client = new MongoClient(mongoUri);

            var db = client.GetDatabase("Genbrug");
            brugerCollection = db.GetCollection<Bruger>("brugere");
        } //Henter informationen som DB skal bruge som navn på DB og Navn på Collection og con string

        public void Add(Bruger item)
        {
            var lastUser = brugerCollection
                .Find(Builders<Bruger>.Filter.Empty) 
                .SortByDescending(b => b.BrugerId)
                .Limit(1)
                .FirstOrDefault();

            item.BrugerId = (lastUser?.BrugerId ?? 0) + 1;

            brugerCollection.InsertOne(item);
            //Ingen filter henter alle documenter
            //Sorter dem så den med højste id kommer først
            //Vælger kun den første 
            //Retunere enten det dokument der blev fundet eller null
            //Øger id værdien med 1 så der altid vil være et nyt id
            //Indsætter den i dokumentet

            //Bruges til at fjerne object string uden problemer for nu
        }

        public void Delete(int id)
        {
            brugerCollection.DeleteOne(b => b.BrugerId == id);
        }
        //...Collection er = IMongoCllection<...>
        // DeleteOne finder det første dokument hvor brugerid == id
        //Så bliver det slettet

        public Bruger[] GetAll()
        {
            return brugerCollection.Find(Builders<Bruger>.Filter.Empty).ToList().ToArray();
        }
        //Henter alle dokumenter fra DB og konverter det til en liste og så en array
    }
}