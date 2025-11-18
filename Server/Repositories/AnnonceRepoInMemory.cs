//using System;
//using System.Diagnostics;
//using Core;
//using Server.PW1;

//namespace Server.Repositories
//{
//    public class AnnonceRepoInMemory : IAnnonceRepo
//    {
//        private static Annonce[] annoncer =
//        {
//            new Annonce {Title = "Hej", Category = "Elektronik", Price = 345, Description = "jkasjdkad"}
//        };

//        private static List<Annonce> mAnonncer = annoncer.ToList();
            
       

//        private static int nextId = 1;

//        public void Add(Annonce annonce)
//        {
//            annonce.AnonnceId = nextId++;
//            mAnonncer.Add(annonce);
//        }

//        public void Delete(int id)
//        {
//            mAnonncer.RemoveAll(a => a.AnonnceId == id);
//        }

//        public List<Annonce> GetAll()
//        {
//            return mAnonncer.ToArray();
//        }
//    }
//} 
