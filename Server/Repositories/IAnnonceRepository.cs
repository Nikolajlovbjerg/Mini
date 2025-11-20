using Core;

namespace Server.Repositories;

public interface IAnnonceRepository
{
    List<Annonce> GetAll();
    
    void Add(Annonce annonce);
    
    void Update(Annonce annonce);

    void Delete(int id);
}
//Siger alle klasser der bruger Interfacet Skal have metoder som GetAll og Add
//Med andre ord det beskriver hvad et repo skal kunne gøre