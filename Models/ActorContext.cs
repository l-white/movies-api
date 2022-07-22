using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace movies_api.Models {
    public class APIContext : DbContext {
        public APIContext (DbContextOptions<APIContext> options) : base (options) { }
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;

    }
}