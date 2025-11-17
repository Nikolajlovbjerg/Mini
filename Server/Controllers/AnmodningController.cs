using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;

namespace Server.Controllers;

[ApiController]
[Route("api/anmodning")]
public class AnmodningController : ControllerBase
{
    private readonly AnmodningsRepository _repo;

    public AnmodningController(AnmodningsRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult Nyt([FromBody] Anmodning a)
    {
        a.AnmodningId = new Random().Next(100000); // midlertidigt
        _repo.Add(a);
        return Ok(a);
    }

    [HttpPut("{id}/accept")]
    public IActionResult Accept(int id)
    {
        _repo.UpdateStatus(id, "accepted");
        return Ok();
    }

    [HttpPut("{id}/reject")]
    public IActionResult Reject(int id)
    {
        _repo.UpdateStatus(id, "rejected");
        return Ok();
    }
}
