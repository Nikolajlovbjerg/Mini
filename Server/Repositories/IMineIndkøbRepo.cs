using Core;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IMineIndkøbRepo
    {
        List<MineIndkøb> GetAll();
        void Add(MineIndkøb køb);
    }
}