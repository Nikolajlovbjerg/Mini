using MongoDB.Driver;
using Core;
using Server.Repositories;


public class AnmodningsRepository : IAnmodningRepo
{
    private readonly IMongoCollection<Anmodning> _collection;

    public AnmodningsRepository(MongoDb db)
    {
        _collection = db.Anmodninger; // collection-navnet matcher MongoDB
    }

    public async Task Create(Anmodning a)
    {
        await _collection.InsertOneAsync(a);
    }

    public async Task<List<Anmodning>> GetByAnnonceId(int annonceId)
    {
        return await _collection
            .Find(a => a.AnnonceId == annonceId)
            .ToListAsync();
    }

    public async Task UpdateStatus(int id, string status)
    {
        var update = Builders<Anmodning>.Update.Set(a => a.Status, status);
        await _collection.UpdateOneAsync(a => a.AnmodningId == id, update);
    }
}