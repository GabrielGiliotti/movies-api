using Microsoft.EntityFrameworkCore;
using movies_api.Models;

namespace movies_api.Infrastructure.Database;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> opts) : base(opts) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder) {}
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieTheater> Theaters { get; set; }
}
