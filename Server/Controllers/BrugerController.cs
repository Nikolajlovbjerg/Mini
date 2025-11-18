using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Core;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/bruger")]
    public class BrugerController : ControllerBase
    {
        private IBrugerRepo brugerRepo;

        public BrugerController(IBrugerRepo brugerRepo)
        {
            this.brugerRepo = brugerRepo;
        }

        [HttpGet]
        public IEnumerable<Bruger> Get()
        {
            return brugerRepo.GetAll();
        }

        [HttpPost]
        public void Add(Bruger bruger)
        {
            brugerRepo.Add(bruger);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id) 
        { 
            brugerRepo.Delete(id);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] int id)
        {
            brugerRepo.Delete(id);
        }


    }
}
