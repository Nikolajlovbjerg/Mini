using Core;

namespace Server.Repositories;

// Her er interfacet, bestemmer man så de metoder der skal findes.
// Derfor er det her ting, hvad man kan gøre 
// CRUD. Create,Read,Update,Delete 
public interface IAnnonceRepository
{
// Henter alle annoncer
    List<Annonce> GetAll();

// Tilføjer ny annonce til repositoriet
    void Add(Annonce annonce);
    
//Opdaterer en eksisterende annonce
    void Update(Annonce annonce);

// Sletter en annonce baseret på dens ID
    void Delete(int id);
}
//Siger alle klasser der bruger Interfacet Skal have metoder som GetAll og Add
//Med andre ord det beskriver hvad et repo skal kunne gøre