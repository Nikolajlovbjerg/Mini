using Core;
using System.Collections.Generic;

namespace Server.Repositories;

public interface IAnmodningRepo
{
    List<Anmodning> GetAll();
    void Add(Anmodning anmod);

    List<Anmodning> GetByAnnonceId(int annonceId);
    void DeleteOtherAnmodninger(int annonceId, int acceptedAnmodningId);
}