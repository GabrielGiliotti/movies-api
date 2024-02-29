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
        var movie = _mapper.Map<MovieTheater>(dto);

        if(movie != null)
            await _repository.AddAsync(movie);
        else
            throw new Exception("Error when adding User");
    }

    public async Task<IEnumerable<MovieTheaterDto>> GetAllMovieTheatersAsync(int skip, int take)
    {
        var movies = await _repository.GetAllAsync(skip, take);
        
        var list = _mapper.Map<IEnumerable<MovieTheaterDto>>(movies);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping User List");
    }

    public async Task<MovieTheaterDto?> GetMovieTheaterByIdAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<MovieTheaterDto>(movie);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping UserDto");
    }

    public async Task UpdateMovieTheaterAsync(MovieTheaterDto obj, int id)
    {
        var toUpdate = await _repository.GetByIdAsync(id) ?? throw new Exception("Movie not found");
        
        if (!string.IsNullOrEmpty(obj.Name) && toUpdate.Name != obj.Name) 
        {
            toUpdate.Name = obj.Name;
        }

        await _repository.UpdateAsync(toUpdate, id);
    }

    public async Task DeleteMovieTheaterAsync(int id) 
    {
        var movie = await _repository.GetByIdAsync(id);

        if(movie == null)
            throw new Exception("User not found");

        await _repository.RemoveAsync(id);
    }
}