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
            opts.UseLazyLoadingProxies().UseMySql(connection, ServerVersion.AutoDetect(connection)));
        
        services.AddScoped<IUnitOfwork, UnitOfwork>();
        
        // Repositories
        services.AddScoped<IRepository<Movie>, Repository<Movie>>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IRepository<MovieTheater>, Repository<MovieTheater>>();
        services.AddScoped<IMovieTheaterRepository, MovieTheaterRepository>();
        services.AddScoped<IRepository<Address>, Repository<Address>>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IRepository<Session>, Repository<Session>>();
        services.AddScoped<ISessionRepository, SessionRepository>();

        // Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IMovieTheaterService, MovieTheaterService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ISessionService, SessionService>();
    }
}