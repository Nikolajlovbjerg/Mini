using Core;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers;

//Markerer klassen som en API-controller og definerer routen for controlleren
    [ApiController]
    [Route("api/annonce")]
    public class AnnonceController : ControllerBase
    {
    //Repository til håndtering af annonce-data
        private IAnnonceRepository aAnnonce;

    //Konstruktor der injicerer annonce-repositoryet
    public AnnonceController(IAnnonceRepository aAnnonce)
        {
            this.aAnnonce = aAnnonce;
        }

    // Metode til at tilføje en ny annonce
        [HttpPost]
        public void Add(Annonce annonce) 
        {
            aAnnonce.Add(annonce); // kalder add metoden i vores repository
    }

    // Metode til at hente alle annoncer
        [HttpGet]
        public IEnumerable<Annonce> GetAll() 
        { 
            return aAnnonce.GetAll(); //Returnerer alle annoncer ved at kalde GetAll metoden i repositoryet
    }

    //Henter en annonce baseret på dens ID
        [HttpGet("{id}")]
        public Annonce GetById(int id)
        {
            //Finder annonce med det givne ID ved at filtrere listen af alle annoncer
            return GetAll().Where(a => a.AnonnceId == id).ToList()[0];
        }
        
    // Opdaterer en eksisterende annonce baseret på dens ID
        [HttpPut("{id}")]
        public IActionResult Update(int id, Annonce annonce)
        {
    // Tjekker om annoncen er null eller om ID'erne ikke matcher
            if (annonce == null || annonce.AnonnceId != id)
                return BadRequest();

            aAnnonce.Update(annonce); // kalder update metoden i vores repository
            return NoContent(); //Returnerer - ingen indhold - statuskode for at indikere succesfuld opdatering
    }
        

        // Sletter en annonce baseret på dens ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
        // Kalder delete metoden i vores repository
            aAnnonce.Delete(id);
            return Ok();
        }
        
    }
        

