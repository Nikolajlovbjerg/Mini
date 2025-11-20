using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;
using System.Collections.Generic;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/mineindkob")]
    public class MineIndkøbController : ControllerBase
    {
        private readonly IMineIndkøbRepo _repo;

        public MineIndkøbController(IMineIndkøbRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<MineIndkøb> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
