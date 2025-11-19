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
    }
