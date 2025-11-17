using MongoDB.Driver;
using Core;
using Server.PW1;

namespace Server.Repositories
{
    public class BrugerRepo : IBrugerRepo
    {
        private IMongoCollection<Bruger> brugerCollection;

        public BrugerRepo()
        {
           var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            //taget fra oles github
            MongoClient client;
            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                throw;
            }

            var dbName = "Genbrug";
            var collectionName = "brugere";
            
            brugerCollection = client.GetDatabase(dbName)
              .GetCollection<Bruger>(collectionName);

        }

        public void Add(Bruger item)
        {
            var bmax = 0;
            if (brugerCollection.CountDocuments(Builders<Bruger>.Filter.Empty) > 0)
            {
                bmax = MaxId();
            }
            item.BrugerId = bmax + 1;
            brugerCollection.InsertOne(item);
        }

        private int MaxId() => GetAll().Select(b => b.BrugerId).Max();

        public void Delete(int id)
        {
            var deleteResult = brugerCollection
                .DeleteOne(Builders<Bruger>.Filter.Where(r => r.BrugerId == id));
        }

        public Bruger[] GetAll()
        {
            var noFilter = Builders<Bruger>.Filter.Empty;
            return brugerCollection.Find(noFilter).ToList().ToArray();
        }

    }
}
