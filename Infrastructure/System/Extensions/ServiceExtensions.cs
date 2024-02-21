using Microsoft.EntityFrameworkCore;
using movies_api.Infrastructure.Database;
using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Infrastructure.System.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services, string connection)
    {
        services.AddDbContext<Context>(opts => 
            opts.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        
        services.AddScoped<IUnitOfwork, UnitOfwork>();
        
        services.AddScoped<IRepository<Movie>, Repository<Movie>>();
        services.AddScoped<IMovieRepository, MovieRepository>();
    }
}