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
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Annonce annonce)
        {
            if (annonce == null || annonce.AnonnceId != id)
                return BadRequest();

            aAnnonce.Update(annonce);
            return NoContent();
        }
        

        // Dette er en routing. Det betyder at denne metode bliver kaldt, når man laver en request gennem urlen. 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
        // kalder delete metoden i vores repository, og har id som parameter. 
            aAnnonce.Delete(id);
            return Ok();
        }
        
    }
        

