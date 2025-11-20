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
//Siger alle klasser der bruger Interfacet Skal have metoder som GetAll og Add
//Med andre ord det beskriver hvad et repo skal kunne gøre
