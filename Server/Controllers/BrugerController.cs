using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using Core;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    [ApiController] //For at håndtere api request
    [Route("api/bruger")] //angiver at alle endpoints i denne controller starter med ... 
    public class BrugerController : ControllerBase
    {
        private IBrugerRepo brugerRepo;

        public BrugerController(IBrugerRepo brugerRepo)
        {
            this.brugerRepo = brugerRepo;
        }
        //Dependency injection af repos som håndtere DB logik
        //Konstrukteren sørger for at controlleren har adgang til Repo

        [HttpGet]
        public IEnumerable<Bruger> Get()
        {
            return brugerRepo.GetAll();
        }
        //Svare på get requests
        //GetAll kalde på repo metoden brugerRepo.GetAll() som retunere alt data fra DB som Json
        //IEnumerable betyder at det er en liste/array af dataen der bliver retuneret

        [HttpPost]
        public void Add(Bruger bruger)
        {
            brugerRepo.Add(bruger);
        }
        //Når klienten sender en post request tilføjes der en ny bruger til DB


        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id)
        {
            brugerRepo.Delete(id);
        }
        //Når klienten sender en delete request fjernes der en bruger med specifikt id i DB

        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] int id)
        {
            brugerRepo.Delete(id);
        }
        //Funktion: Sletter brugeren med id fra query-string i stedet for URL-path.

        //FromQuery fortæller, at parameteren hentes fra query string.

    }
}
