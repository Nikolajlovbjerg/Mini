using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;
using System.Collections.Generic;

namespace Server.Controllers
{
    [ApiController] //For at håndtere api request
    [Route("api/mineindkob")] //angiver alle at alle endpoints i denne controller starter med ... 
    public class MineIndkobController : ControllerBase
    {
        private readonly IMineIndkobRepo _repo;

        public MineIndkobController(IMineIndkobRepo repo)
        {
            _repo = repo;
        }
        //Dependency injection af repos som håndtere DB logik
        //Konstrukteren sørger for at controlleren har adgang til Repo

        [HttpGet] //Endpoint
        public IEnumerable<MineIndkob> GetAll()
        {
            return _repo.GetAll();
        }
        //Svare på get requests
        //GetAll kalde på repo metoden _repo.GetAll() som retunere alt data fra DB som Json
        //IEnumerable betyder at det er en liste/array af dataen der bliver retuneret
    }
}
