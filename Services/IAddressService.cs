using movies_api.DTOs;

namespace movies_api.Services;

public interface IAddressService
{
    Task AddAddressAsync(AddressDto obj);
    Task<AddressDto?> GetAddressByIdAsync(int id);
    Task<IEnumerable<AddressDto>> GetAllAddressesAsync(int skip, int take);
    Task UpdateAddressAsync(AddressDto obj, int id);
    Task DeleteAddressAsync(int id);
}