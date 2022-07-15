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
    [HttpPost]
    public IActionResult Create(Actor actor)
    {
        // Save the actor and return a result
        ActorService.Add(actor);
        return CreatedAtAction(nameof(Create), new { id = actor.id }, actor);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Actor actor)
    {
        // Update the actor and return a result
        if (id != actor.id)
            return BadRequest();

        var existingPizza = ActorService.Get(id);
        if (existingPizza is null)
            return NotFound();

        ActorService.Update(actor);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Delete an actor and return a result
        var actor = ActorService.Get(id);

        if (actor is null)
            return NotFound();

        ActorService.Delete(id);

        return NoContent();
    }
}