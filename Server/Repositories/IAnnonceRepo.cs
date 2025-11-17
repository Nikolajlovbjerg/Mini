using Core;
namespace Server.Repositories
{
    public interface IAnnonceRepo
    {
        Annonce[] GetAll();
        void add (Annonce annonce);
        void delete (int id);
    }
}
