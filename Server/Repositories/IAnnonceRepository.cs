using Core;

namespace Server.Repositories;

public interface IAnnonceRepository
{
    List<Annonce> GetAll();
    
    void Add(Annonce annonce);
}