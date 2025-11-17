using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Core;
using ZstdSharp.Unsafe;


namespace Server.Controllers
{
    [ApiController]
    [Route("api/annoncer")]
    public class AnnonceController : ControllerBase
    {
        private IAnnonceRepo AnnonceRepo;

        public AnnonceController(IAnnonceRepo AnnonceRepo)
        {
            this.AnnonceRepo = AnnonceRepo;
        }

        [HttpGet]
        public IEnumerable<Annonce> Get()
        {
            return AnnonceRepo.GetAll();
        }
        [HttpPost]
        public void Add(Annonce annonce) { 
        AnnonceRepo.add(annonce);
        }
        
        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id) {
            AnnonceRepo.delete(id);
        }
    }
}