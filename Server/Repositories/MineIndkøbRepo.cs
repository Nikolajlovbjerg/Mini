using Core;
using MongoDB.Driver;
using Server.PW1;
using System.Collections.Generic;

namespace Server.Repositories
{
    public class MineIndkøbRepository : IMineIndkøbRepo
    {
        private readonly IMongoCollection<MineIndkøb> _mkøb;

        public MineIndkøbRepository()
        {
            var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            var client = new MongoClient(mongoUri);
            var database = client.GetDatabase("Genbrug");
            _mkøb = database.GetCollection<MineIndkøb>("mineindkøb");
        }

        public List<MineIndkøb> GetAll()
        {
            return _mkøb.Find(_ => true).ToList();
        }

        public void Add(MineIndkøb køb)
        {
            var last = _mkøb.Find(Builders<MineIndkøb>.Filter.Empty)
                            .SortByDescending(m => m.KøbId)
                            .Limit(1)
                            .FirstOrDefault();
            køb.KøbId = (last?.KøbId ?? 0) + 1;

            _mkøb.InsertOne(køb);
        }
    }
}
