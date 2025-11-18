using MongoDB.Driver;
using Core;

namespace Server.Repositories
{
    public class AnnonceRepoMongodb : IAnnonceRepo
    {
        private readonly IMongoCollection<Annonce> _collection;

        public AnnonceRepoMongodb()
        {
            // Hardcoded
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "AnnonceDB";
            string collectionName = "Annonce";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<Annonce>(collectionName);
        }

        public void add(Annonce annonce)
        {
            if (annonce.AnonnceId == 0)
            {
                annonce.AnonnceId = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
            }

            _collection.InsertOne(annonce);
        }

        public void delete(int id)
        {
            _collection.DeleteOne(a => a.AnonnceId == id);
        }

        public Annonce[] GetAll()
        {
            return _collection.Find(_ => true).ToList().ToArray();
        }
    }
}
