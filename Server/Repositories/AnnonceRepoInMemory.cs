using System;
using System.Diagnostics;
using Core;
using Server.PW1;

namespace Server.Repositories
{
    public class AnnonceRepoInMemory : IAnnonceRepo
    {
        private static Annonce[] annoncer =
        {
            new Annonce {Title = "Hej", Category = "Elektronik", Price = 345, Description = "jkasjdkad"}
        };

        private static List<Annonce> mAnonncer = annoncer.ToList();
            
        public void test()
        {
            PASSWORD pw = new PASSWORD();

            if (PASSWORD.tal == 4)
            {
                Console.WriteLine("amonng us");
            }
        }


        private static int nextId = 1;

        public void add(Annonce annonce)
        {
            annonce.AnonnceId = nextId++;
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
