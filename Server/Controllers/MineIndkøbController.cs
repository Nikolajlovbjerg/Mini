using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Core;

namespace Server.Controllers;

[ApiController]
[Route("api/mineindkøb")]
public class MineIndkøbController : ControllerBase
{
    private readonly IMineIndkøbRepo _Indkøbrepo;

    public MineIndkøbController(IMineIndkøbRepo repo)
    {
        _Indkøbrepo = repo;
    }

    [HttpGet("{buyerId}")]
    public IEnumerable<MineIndkøb> GetMineKøb(int buyerId)
    {
        return _Indkøbrepo.GetAllByBuyerId(buyerId);
    }
}
