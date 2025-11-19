using MongoDB.Driver;
using Core;

namespace Server.Repositories;

public class AnmodningsRepository : IAnmodningRepo
{
    private readonly IMongoCollection<Anmodning> _collection;

    public AnmodningsRepository(MongoDb db)
    {
        _collection = db.Anmodninger;
    }

    public List<Anmodning> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public void Add(Anmodning a)
    {
        // lav manuelt autoincrement ID (samme stil som jeres andre repos)
        var last = _collection
            .Find(Builders<Anmodning>.Filter.Empty)
            .SortByDescending(x => x.AnmodningId)
            .Limit(1)
            .FirstOrDefault();

        a.AnmodningId = (last?.AnmodningId ?? 0) + 1;
        a.Status = a.Status ?? "pending";
        a.Date = DateTime.UtcNow;

        _collection.InsertOne(a);
    }
}