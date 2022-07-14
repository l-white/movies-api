using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace movies_api.Models
{
    public class ActorContext : DbContext
    {
        public ActorContext(DbContextOptions<ActorContext> options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; } = null!;
    }
}
