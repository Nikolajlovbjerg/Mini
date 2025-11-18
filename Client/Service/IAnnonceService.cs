using Core;

namespace Client.Service
{
    public interface IAnnonceService
    {
        Task<List<Annonce>?> GetAll();
        Task Add(Annonce annonce);
        //Task DeleteById(int id);
    }

}
