using Core;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IMineIndkobRepo
    {
        List<MineIndkob> GetAll();
        void Add(MineIndkob kob);
    }
}