using Core;
using System.Collections.Generic;

namespace Server.Repositories;

public interface IAnmodningRepo
{
    List<Anmodning> GetAll();
    List<Anmodning> GetByAnnonceId(int annonceId);
    void Add(Anmodning anmod);
}