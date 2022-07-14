using movies_api.Models;

namespace movies_api.Services;

public static class ActorService
{
    static List<Actor> Actors { get; }
    static int nextId = 3;
    static ActorService()
    {
        Actors = new List<Actor>
        {
            new Actor { id = 1, title = "Moonstruck", poster = "Moonstruck", release_date = new DateTime(1987, 1, 1) },
            new Actor { id = 2, title = "Overboard", poster = "Overboard", release_date = new DateTime(1986, 3, 3) }
        };
    }

    public static List<Actor> GetAll() => Actors;

    public static Actor? Get(int id) => Actors.FirstOrDefault(p => p.id == id);

    public static void Add(Actor actor)
    {
        actor.id = nextId++;
        Actors.Add(actor);
    }

    public static void Delete(int id)
    {
        var actor = Get(id);
        if (actor is null)
            return;

        Actors.Remove(actor);
    }

    public static void Update(Actor actor)
    {
        var index = Actors.FindIndex(p => p.id == actor.id);
        if (index == -1)
            return;

        Actors[index] = actor;
    }
}