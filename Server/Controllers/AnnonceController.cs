using Core;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers;

    [ApiController]
    [Route("api/annonce")]
    public class AnnonceController : ControllerBase
    {
        private IAnnonceRepository aAnnonce;

        public AnnonceController(IAnnonceRepository aAnnonce)
        {
            this.aAnnonce = aAnnonce;
        }

        [HttpPost]
        public void Add(Annonce annonce) 
        {
            aAnnonce.Add(annonce);
        }

        [HttpGet]
        public IEnumerable<Annonce> GetAll() 
        { 
            return aAnnonce.GetAll();
        }

        [HttpGet("{id}")]
        public Annonce GetById(int id)
        {
            return GetAll().Where(a => a.AnonnceId == id).ToList()[0];
        }
          [HttpDelete("{id}")]
        public IActionResult Delete(int id)
         {
        aAnnonce.Delete(id);
        return Ok();
          }

}
