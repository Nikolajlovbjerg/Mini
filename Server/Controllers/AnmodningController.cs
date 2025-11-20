using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;
using MongoDB.Driver;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/anmodning")]
    public class AnmodningController : ControllerBase
    {
        private readonly IAnmodningRepo _AnmodCollection;
        private readonly IMineIndkøbRepo _MineIndkøbRepo;

        public AnmodningController(IAnmodningRepo anmodCollection, IMineIndkøbRepo mineIndkøbRepo)
        {
            _AnmodCollection = anmodCollection;
            _MineIndkøbRepo = mineIndkøbRepo;
        }

        [HttpGet]
        public IEnumerable<Anmodning> GetAll()
        {
            return _AnmodCollection.GetAll();
        }

        [HttpPost]
        public void Add(Anmodning anmod)
        {
            _AnmodCollection.Add(anmod);
        }

        [HttpGet("by-annonce/{annonceId}")]
        public IEnumerable<Anmodning> GetByAnnonce(int annonceId)
        {
            return _AnmodCollection.GetByAnnonceId(annonceId);
        }

        [HttpPost("accepter/{anmodningId}")]
        public IActionResult AccepterAnmodning(int anmodningId)
        {
            var anmod = _AnmodCollection.GetAll().FirstOrDefault(a => a.AnmodningId == anmodningId);
            if (anmod == null) return NotFound();

            // Flyt til MineIndkøb
            var køb = new MineIndkøb
            {
                AnnonceId = anmod.AnnonceId,
                BuyerId = anmod.BuyerId,
                SælgerId = anmod.BrugerId,
                Status = "accepteret",
                Created = DateTime.UtcNow
            };
            _MineIndkøbRepo.Add(køb);

            // Slet accepteret anmodning fra Anmodning
            var filter = Builders<Anmodning>.Filter.Eq(a => a.AnmodningId, anmodningId);
            _AnmodCollection.DeleteOtherAnmodninger(anmod.AnnonceId, anmodningId);

            return Ok();
        }
    }
}