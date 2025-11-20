using Core;
using System.Collections.Generic;

namespace Server.Repositories;

public interface IMineIndkøbRepo
{
    void Add(MineIndkøb køb);
    List<MineIndkøb> GetAllByBuyerId(int buyerId);
}
