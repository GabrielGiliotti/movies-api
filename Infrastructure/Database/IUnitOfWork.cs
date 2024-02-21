namespace movies_api.Infrastructure.Database;

public interface IUnitOfwork : IDisposable
{
    Context Context { get; }
    public Task SaveChangesAsync();
}