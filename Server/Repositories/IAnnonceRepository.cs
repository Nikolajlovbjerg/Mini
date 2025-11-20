using Core;

namespace Server.Repositories;

// her er interfacet, bestemmer man så de metoder der skal findes.
// derfor er det her ting, hvad man kan gøre 
// CRUD. Create,Read,Update,Delete 
public interface IAnnonceRepository
{
    List<Annonce> GetAll();
    
    void Add(Annonce annonce);
    
    void Update(Annonce annonce);

    void Delete(int id);
}