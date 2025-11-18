using MongoDB.Driver;
using Core;

namespace Server.Repositories;

public class MongoDb
{
    private readonly IMongoDatabase _database;

    public MongoDb(IConfiguration config)
    {
        var connectionString = config["MongoDbSettings:ConnectionString"];
        var dbName = config["MongoDbSettings:DatabaseName"];

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(dbName))
            throw new Exception("MongoDB connection settings missing!");

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(dbName);
    }

    public IMongoCollection<Anmodning> Anmodninger => _database.GetCollection<Anmodning>("Anmodninger");
    public IMongoCollection<Annonce> Annoncer => _database.GetCollection<Annonce>("Annoncer");
}