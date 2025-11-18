using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Core;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/annoncer")]
    public class AnnonceController : ControllerBase
    {
        private readonly IAnnonceRepo AnnonceRepo;

        public AnnonceController(IAnnonceRepo AnnonceRepo)
        {
            this.AnnonceRepo = AnnonceRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var annoncer = AnnonceRepo.GetAll();
            return Ok(annoncer);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Annonce annonce)
        {
            if (annonce == null)
                return BadRequest("Annonce er null");

            AnnonceRepo.Add(annonce);
            return Ok(annonce);
        }

    }
}
