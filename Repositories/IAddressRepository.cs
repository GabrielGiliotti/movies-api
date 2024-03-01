using movies_api.Models;

namespace movies_api.Repositories;

public interface IAddressRepository
{
    Task AddAsync(Address obj);
    Task<Address?> GetByIdAsync(int id);
    Task<IEnumerable<Address>> GetAllAsync(int skip, int take);
    Task UpdateAsync(Address obj, int id);
    Task RemoveAsync(int id);
}