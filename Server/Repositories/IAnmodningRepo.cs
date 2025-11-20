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
//Siger alle klasser der bruger Interfacet Skal have metoder som GetAll og Add
//Med andre ord det beskriver hvad et repo skal kunne g�re