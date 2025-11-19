using Core;

namespace Server.Repositories;

public interface IAnnonceRepo
{
    List<Annonce> GetAll();

    void Add(Annonce annonce);
}
