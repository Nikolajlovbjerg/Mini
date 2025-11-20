using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;

namespace Server.Controllers;

[ApiController]
[Route("api/anmodning")]
public class AnmodningController : ControllerBase
{
    private readonly IAnmodningRepo _AnmodCollection;

    public AnmodningController(IAnmodningRepo _AnmodCollection)
    {
        //Dependency injection af vores Repository
        this._AnmodCollection = _AnmodCollection;
    }

    [HttpGet] 
    public IEnumerable<Anmodning> GetAll()
    {
        //Henter alle anmodninger som bruges af siden til at hente data
        return _AnmodCollection.GetAll();
    }

    [HttpPost]
    public void Add(Anmodning anmod)
    {
        // Giver anmodnings-objektet videre til repositoryet (indsæt i databasen)
        _AnmodCollection.Add(anmod);
    }

    [HttpGet("byAnnonce/{annonceId}")]
    public IEnumerable<Anmodning> GetByAnnonceId(int annonceId)
    {
        // Henter alle anmodninger til en bestemt annonce
        return _AnmodCollection.GetByAnnonceId(annonceId);
    }

    [HttpPut("accept/{annonceId}/{anmodningId}")]
    public void Accept(int annonceId, int anmodningId)
    {
        // Accepter en anmodning (og afvis andre)
        _AnmodCollection.AcceptAnmodning(annonceId, anmodningId);
    }

    [HttpPut("acceptMove/{annonceId}/{anmodningId}")]
    public IActionResult AcceptAndMove(int annonceId, int anmodningId)
    {
        // Accepter OG flyt til MineIndkøb
        _AnmodCollection.AcceptAndMove(annonceId, anmodningId);
        return Ok();
    }
}