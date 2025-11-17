using Core;

namespace Server.Repositories;

public class AnmodningsRepository
{
    private static List<Anmodning> _data = new();

    public List<Anmodning> GetByAnnonceId(int annonceId)
    {
        return _data.Where(a => a.AnnonceId == annonceId).ToList();
    }

    public void Add(Anmodning a)
    {
        _data.Add(a);
    }

    public void UpdateStatus(int id, string status)
    {
        var req = _data.FirstOrDefault(x => x.AnmodningId == id);
        if (req != null)
            req.Status = status;
    }
}
