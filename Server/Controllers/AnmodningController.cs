using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;

[ApiController]
[Route("api/anmodning")]
public class AnmodningController : ControllerBase
{
    private readonly IAnmodningRepo _repo;

    public AnmodningController(IAnmodningRepo repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Nyt([FromBody] Anmodning a)
    {
        await _repo.Create(a); // gemmer i MongoDB
        return Ok(a);
    }

    [HttpPut("{id}/accept")]
    public async Task<IActionResult> Accept(int id)
    {
        await _repo.UpdateStatus(id, "accepted");
        return Ok();
    }

    [HttpPut("{id}/reject")]
    public async Task<IActionResult> Reject(int id)
    {
        await _repo.UpdateStatus(id, "rejected");
        return Ok();
    }
}
