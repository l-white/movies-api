using movies_api.Models;
using movies_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ActorController.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{
    public ActorController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Actor>> GetAll() =>
    ActorService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Actor> Get(int id)
    {
        var actor = ActorService.Get(id);

        if (actor == null)
            return NotFound();

        return actor;
    }

    // POST action

    // PUT action

    // DELETE action
}