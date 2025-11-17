using System;
using Core;
namespace Server.Repositories
{
    public class AnnonceRepoInMemory : IAnnonceRepo
    {
        private static Annonce[] annoncer = { };

        private static List<Annonce> mAnonncer = annoncer.ToList();
            

        public void add(Annonce annonce)
        {
            mAnonncer.Add(annonce);
        }

        public void delete(int id)
        {
            mAnonncer.RemoveAll(a => a.AnonnceId == id);
        }

        public Annonce[] GetAll()
        {
            return mAnonncer.ToArray();
        }
    }
} 
