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
        }

        public void Add(Bruger item)
        {
            // Find højeste eksisterende BrugerId
            var lastUser = brugerCollection
                .Find(Builders<Bruger>.Filter.Empty)
                .SortByDescending(b => b.BrugerId)
                .Limit(1)
                .FirstOrDefault();

            item.BrugerId = (lastUser?.BrugerId ?? 0) + 1;

            brugerCollection.InsertOne(item);
        }

        public void Delete(int id)
        {
            brugerCollection.DeleteOne(b => b.BrugerId == id);
        }

        public Bruger[] GetAll()
        {
            return brugerCollection.Find(Builders<Bruger>.Filter.Empty).ToList().ToArray();
        }
    }
}