using Core;
using MongoDB.Driver;
using Server.PW1;

namespace Server.Repositories;

public class MineIndkøbRepository : IMineIndkøbRepo
{
    private readonly IMongoCollection<MineIndkøb> _Indkøbcollection;

    public MineIndkøbRepository()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        _Indkøbcollection = database.GetCollection<MineIndkøb>("mineindkøb");
    }

    public void Add(MineIndkøb køb)
    {
        var last = _Indkøbcollection.Find(_ => true)
                              .SortByDescending(k => k.Id)
                              .Limit(1)
                              .FirstOrDefault();
        køb.Id = (last?.Id ?? 0) + 1;
        _Indkøbcollection.InsertOne(køb);
    }

    public List<MineIndkøb> GetAllByBuyerId(int buyerId)
    {
        return _Indkøbcollection.Find(k => k.BuyerId == buyerId).ToList();
    }
}