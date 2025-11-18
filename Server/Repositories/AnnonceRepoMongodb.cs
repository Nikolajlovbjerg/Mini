using MongoDB.Driver;
using Core;
using System.Collections.Generic;
using Server.PW1;

namespace Server.Repositories
{
    public class AnnonceRepoMongodb : IAnnonceRepo
    {
        private readonly IMongoCollection<Annonce> annonceCollection;

        public AnnonceRepoMongodb()
        {
           
        
            var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            var client = new MongoClient(mongoUri);

            var db = client.GetDatabase("Genbrug");
            annonceCollection = db.GetCollection<Annonce>("Annonce");
        
        }

        public void add(Annonce annonce)
        {
            if (annonce != null)
            {
                annonceCollection.InsertOne(annonce);
            }
        }


        public void delete(string id)
        {
            var filter = Builders<Annonce>.Filter.Eq(a => a.Id, id);
            annonceCollection.DeleteOne(filter);
        }
        public Annonce[] GetAll()
        {
            return annonceCollection.Find(_ => true).ToList().ToArray();
        }
    }
}
