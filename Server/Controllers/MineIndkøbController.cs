using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;
using System.Collections.Generic;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/mineindkob")]
    public class MineIndkobController : ControllerBase
    {
        private readonly IMineIndkobRepo _repo;

        public MineIndkobController(IMineIndkobRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<MineIndkob> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
