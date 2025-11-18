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

            try
            {
                var lastAnnonce = AnnonceRepo.GetAll()
                                    .OrderByDescending(a => a.AnonnceId)
                                    .FirstOrDefault();
                annonce.AnonnceId = (lastAnnonce?.AnonnceId ?? 0) + 1;

                AnnonceRepo.Add(annonce);
                return Ok(annonce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
