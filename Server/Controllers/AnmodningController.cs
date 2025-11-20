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
        this._AnmodCollection = _AnmodCollection;
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

    [HttpGet("byAnnonce/{annonceId}")]
    public IEnumerable<Anmodning> GetByAnnonceId(int annonceId)
    {
        return _AnmodCollection.GetByAnnonceId(annonceId);
    }

    [HttpPut("accept/{annonceId}/{anmodningId}")]
    public void Accept(int annonceId, int anmodningId)
    {
        _AnmodCollection.AcceptAnmodning(annonceId, anmodningId);
    }

    [HttpPut("acceptMove/{annonceId}/{anmodningId}")]
    public IActionResult AcceptAndMove(int annonceId, int anmodningId)
    {
        _AnmodCollection.AcceptAndMove(annonceId, anmodningId);
        return Ok();
    }
}