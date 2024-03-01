using movies_api.Infrastructure.Database;
using movies_api.Models;

namespace movies_api.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly IRepository<Address> _repo;
    
    public AddressRepository(IRepository<Address> repo) 
    {
        _repo = repo;
    }

    public async Task AddAsync(Address obj)
    {
        await _repo.Create(obj);
    }

    public async Task<IEnumerable<Address>> GetAllAsync(int skip, int take)
    {
        var movies = await _repo.GetAll();

        return movies.Skip(skip).Take(take);
    }

    public async Task<Address?> GetByIdAsync(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task RemoveAsync(int id)
    {
        await _repo.Delete(id);
    }

    public async Task UpdateAsync(Address obj, int id)
    {
        await _repo.Update(id, obj);
    }
}