using Microsoft.AspNetCore.Mvc;
using Core;
using Server.Repositories;

[ApiController]
[Route("api/anmodning")]
public class AnmodningController : ControllerBase
{
    private readonly IAnmodningRepo repo;

    public AnmodningController(IAnmodningRepo repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public IEnumerable<Anmodning> GetAll()
    {
        return repo.GetAll();
    }

    [HttpPost]
    public void Add(Anmodning a)
    {
        repo.Add(a);
    }
}