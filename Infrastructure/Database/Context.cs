using Microsoft.EntityFrameworkCore;
using movies_api.Models;

namespace movies_api.Infrastructure.Database;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> opts) : base(opts) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {   
        modelBuilder.Entity<Session>()
            .HasOne(session => session.MovieTheater)
            .WithMany(movieTheater => movieTheater.Sessions)
            .HasForeignKey(session => session.MovieTheaterId);

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Movie)
            .WithMany(movie => movie.Sessions)
            .HasForeignKey(session => session.MovieId);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieTheater> MovieTheaters { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}
