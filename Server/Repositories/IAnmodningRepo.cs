using Core;
using System.Collections.Generic;

namespace Server.Repositories;

public interface IAnmodningRepo
{
    Task Create(Anmodning a);
    Task<List<Anmodning>> GetByAnnonceId(int annonceId);
    Task UpdateStatus(int id, string status);
}