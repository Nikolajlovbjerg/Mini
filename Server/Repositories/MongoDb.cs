//using MongoDB.Driver;
//using Core;

//namespace Server.Repositories;

//public class MongoDb
//{
//    private readonly IMongoDatabase _db;

//    public IMongoCollection<Anmodning> Anmodninger => _db.GetCollection<Anmodning>("Anmodninger");

//    public MongoDb()
//    {
//        var client = new MongoClient("mongodb://localhost:27017");
//        _db = client.GetDatabase("GenbrugsMarked"); 
//    }
//}