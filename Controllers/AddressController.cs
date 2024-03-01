using Microsoft.AspNetCore.Mvc;
using movies_api.DTOs;
using movies_api.Services;

namespace movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly ILogger<AddressController> _logger;
    private readonly IAddressService _addressService;

    public AddressController(ILogger<AddressController> logger, IAddressService addressService)
    {
        _logger = logger;
        _addressService = addressService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress(AddressDto obj) 
    {
        await _addressService.AddAddressAsync(obj);

        return StatusCode(201, obj); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAddressesPaged([FromQuery] int skip = 0, [FromQuery] int take = 100) 
    {
        var addresses = await _addressService.GetAllAddressesAsync(skip, take);
        
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id) 
    {
        var address = await _addressService.GetAddressByIdAsync(id);
        
        return Ok(address);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDto obj) 
    {
        await _addressService.UpdateAddressAsync(obj, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id) 
    {
        await _addressService.DeleteAddressAsync(id);

        return NoContent();
    }
}