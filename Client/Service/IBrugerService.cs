using Core;

namespace Client.Service
{
    public interface IBrugerService
    {
        Task<Bruger[]?> GetAll();
        Task Add(Bruger bruger);
        Task DeleteById(int id);
    }
}
