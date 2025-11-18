using Core;

namespace Server.Repositories.TEST;

public interface IAnnonceRepository
{
    List<Annonce> GetAll();
    
    void Add(Annonce annonce);
}