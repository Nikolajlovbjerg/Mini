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

        public void Add(Annonce annonce)
        {
            var lastAnnonce = annonceCollection
                .Find(FilterDefinition<Annonce>.Empty)
                .SortByDescending(a => a.AnonnceId)
                .FirstOrDefault();

            annonce.AnonnceId = (lastAnnonce?.AnonnceId ?? 0) + 1;

            annonceCollection.InsertOne(annonce);
        }


        //public void Delete(int id)
        //{
        //    annonceCollection.DeleteOne(a => a.AnonnceId == id);
        //}
        public List<Annonce> GetAll()
        {
            return annonceCollection.Find(_  => true).ToList();
        }
    }
}
