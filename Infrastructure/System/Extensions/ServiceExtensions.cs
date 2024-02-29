using Microsoft.EntityFrameworkCore;
using movies_api.Infrastructure.Database;
using movies_api.Models;
using movies_api.Repositories;
using movies_api.Services;

namespace movies_api.Infrastructure.System.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services, string connection)
    {
        // Database
        services.AddDbContext<Context>(opts => 
            opts.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        
        services.AddScoped<IUnitOfwork, UnitOfwork>();
        
        // Repositories
        services.AddScoped<IRepository<Movie>, Repository<Movie>>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IRepository<MovieTheater>, Repository<MovieTheater>>();
        services.AddScoped<IMovieTheaterRepository, MovieTheaterRepository>();

        // Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IMovieTheaterService, MovieTheaterService>();
    }
}