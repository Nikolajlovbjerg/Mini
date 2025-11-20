using Core;
using MongoDB.Driver;
using Server.PW1;
using System.Collections.Generic;

namespace Server.Repositories
{
    public class MineIndkobRepository : IMineIndkobRepo
    {
        private readonly IMongoCollection<MineIndkob> _mkob;

        public MineIndkobRepository()
        {
            var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            var client = new MongoClient(mongoUri);
            var database = client.GetDatabase("Genbrug");
            _mkob = database.GetCollection<MineIndkob>("mineindkob");
            //Henter connection string til mongo databasen og forbinder den til den rigtige database og collection
        }

        public List<MineIndkob> GetAll()
        {
            return _mkob.Find(_ => true).ToList(); //Henter alle dokumenter fra DB og konverter det til en liste
        }

        public void Add(MineIndkob kob)
        {
            var last = _mkob.Find(Builders<MineIndkob>.Filter.Empty) //Ingen filter henter alle documenter
                            .SortByDescending(m => m.KobId) //Sorter dem så den med højste id kommer først
                            .Limit(1) //Vælger kun den første 
                            .FirstOrDefault(); //Retunere enten det dokument der blev fundet eller null
            kob.KobId = (last?.KobId ?? 0) + 1; //Øger id værdien med 1 så der altid vil være et nyt id 
            //Bruges til at fjerne object string uden problemer for nu

            _mkob.InsertOne(kob); //Indsætter den i dokumentet
        }
    }
}
