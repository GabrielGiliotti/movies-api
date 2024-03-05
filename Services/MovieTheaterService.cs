using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Services;

public class MovieTheaterService : IMovieTheaterService
{
    private readonly IMovieTheaterRepository _repository;
    private readonly IMapper _mapper;
    
    public MovieTheaterService(IMapper mapper, IMovieTheaterRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task AddMovieTheaterAsync(MovieTheaterDto dto)
    {
        var movieTheater = _mapper.Map<MovieTheater>(dto);

        if(movieTheater != null)
            await _repository.AddAsync(movieTheater);
        else
            throw new Exception("Error when adding User");
    }

    public async Task<IEnumerable<MovieTheaterDto>> GetAllMovieTheatersAsync(int skip, int take, int? addressId)
    {
        var movieTheaters = await _repository.GetAllAsync(skip, take, addressId);
        
        var list = _mapper.Map<IEnumerable<MovieTheaterDto>>(movieTheaters);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping MovieTheater List");
    }

    public async Task<MovieTheaterDto?> GetMovieTheaterByIdAsync(int id)
    {
        var movieTheater = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<MovieTheaterDto>(movieTheater);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping MovieTheaterDto");
    }

    public async Task UpdateMovieTheaterAsync(MovieTheaterDto obj, int id)
    {
        var toUpdate = await _repository.GetByIdAsync(id) ?? throw new Exception("MovieTheater not found");
        
        if (!string.IsNullOrEmpty(obj.Name) && toUpdate.Name != obj.Name) 
        {
            toUpdate.Name = obj.Name;
        }

        await _repository.UpdateAsync(toUpdate, id);
    }

    public async Task DeleteMovieTheaterAsync(int id) 
    {
        var movieTheater = await _repository.GetByIdAsync(id);

        if(movieTheater == null)
            throw new Exception("MovieTheater not found");

        await _repository.RemoveAsync(id);
    }
}