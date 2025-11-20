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
        }

        public List<MineIndkob> GetAll()
        {
            return _mkob.Find(_ => true).ToList();
        }

        public void Add(MineIndkob kob)
        {
            var last = _mkob.Find(Builders<MineIndkob>.Filter.Empty)
                            .SortByDescending(m => m.KobId)
                            .Limit(1)
                            .FirstOrDefault();
            kob.KobId = (last?.KobId ?? 0) + 1;

            _mkob.InsertOne(kob);
        }
    }
}
