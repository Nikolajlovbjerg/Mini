using Core;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IAnmodningRepo
    {
        List<Anmodning> GetAll();
        List<Anmodning> GetByAnnonceId(int annonceId);
        void Add(Anmodning anmod);

        // Accepter en anmodning (sæt status)
        void AcceptAnmodning(int annonceId, int anmodningId);

        // Accepter en anmodning OG flyt til MineIndkøb + slet fra Annonce og Anmodning
        void AcceptAndMove(int annonceId, int anmodningId);
    }
}