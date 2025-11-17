using System;
using Core;


namespace Server.Repositories
{
    public interface IBrugerRepo
    {
        Bruger[] GetAll();
        void Add(Bruger bruger);
        void Delete(int id);
    }
}
