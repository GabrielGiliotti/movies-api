using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;
    private readonly IMapper _mapper;
    
    public AddressService(IMapper mapper, IAddressRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task AddAddressAsync(AddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);

        if(address != null)
            await _repository.AddAsync(address);
        else
            throw new Exception("Error when adding Address");
    }

    public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync(int skip, int take)
    {
        var addresses = await _repository.GetAllAsync(skip, take);
        
        var list = _mapper.Map<IEnumerable<AddressDto>>(addresses);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping Address List");
    }

    public async Task<AddressDto?> GetAddressByIdAsync(int id)
    {
        var address = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<AddressDto>(address);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping AddressDto");
    }

    public async Task UpdateAddressAsync(AddressDto obj, int id)
    {
        var toUpdate = await _repository.GetByIdAsync(id) ?? throw new Exception("Address not found");
        
        if (!string.IsNullOrEmpty(obj.PublicPlace) && toUpdate.PublicPlace != obj.PublicPlace) 
        {
            toUpdate.PublicPlace = obj.PublicPlace;
        }

        if(toUpdate.Number != obj.Number) 
        {
            toUpdate.Number = obj.Number;
        }

        await _repository.UpdateAsync(toUpdate, id);
    }

    public async Task DeleteAddressAsync(int id) 
    {
        var address = await _repository.GetByIdAsync(id);

        if(address == null)
            throw new Exception("Address not found");

        await _repository.RemoveAsync(id);
    }
}