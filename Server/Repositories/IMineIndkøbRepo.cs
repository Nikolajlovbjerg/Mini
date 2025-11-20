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
//Siger alle klasser der bruger Interfacet Skal have metoder som GetAll og Add
//Med andre ord det beskriver hvad et repo skal kunne gøre